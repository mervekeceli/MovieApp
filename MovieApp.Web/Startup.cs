using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Microsoft.Extensions.Hosting;
using MovieApp.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MovieContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MsSQLConnection")));
                //options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews() // MVC yap�s�n� projemizde kullanaca��m�z� belirtiyoruz.
                .AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled=true);  //Client validation aktif etme
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                DataSeeding.Seed(app); // test verilerinin eklenmesi ayar�
            }

            app.UseRouting();

            app.UseStaticFiles(); // RES�MLER� �G�STERMEY� AKT�F HALE GET�RME

            //localhost:5000
            //localhost:5000/movies
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}"
                );
            });
        }
    }
}
