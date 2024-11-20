using System.Collections.Generic;
using System.Security;

namespace MovieApp.Web.Model
{
    public class AdminGenresViewModel
    {
        public List<AdminGenreViewModel> Genres { get; set; }
    }

    public class AdminGenreViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; } //Her türde kaç tane film bilgisi varsa onu göstermek için
    }
}
