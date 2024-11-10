using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Web.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Data
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();

            context.Database.Migrate();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Movies.Count() == 0)
                {
                    context.Movies.AddRange(new List<Movie>() {
                        new Movie{Title = "Film 1", Description= "Aciklama 1", ImageUrl = "1.jpg", GenreId = 1},
                        new Movie{Title = "Film 2", Description= "Aciklama 2", ImageUrl = "2.jpg", GenreId = 2},
                        new Movie{Title = "Film 3", Description= "Aciklama 3", ImageUrl = "3.jpg", GenreId = 4},
                        new Movie{Title = "Film 4", Description= "Aciklama 4", ImageUrl = "1.jpg", GenreId = 3},
                        new Movie{Title = "Film 5", Description= "Aciklama 5", ImageUrl = "2.jpg", GenreId = 1},
                        new Movie{Title = "Film 6", Description= "Aciklama 6", ImageUrl = "3.jpg", GenreId = 2}
                    });
                }
                if(context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(new List<Genre>() {
                        new Genre{Name="Macera"},
                        new Genre{Name="Komedi"},
                        new Genre{Name="Romantik"},
                        new Genre{Name="Bilim Kurgu"},
                        new Genre{Name="Aksiyon"},
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
