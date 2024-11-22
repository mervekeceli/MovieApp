using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace MovieApp.Web.Model
{
    public class AdminGenresViewModel
    {
        [Required(ErrorMessage ="Tür bilgisi girmelisiniz!")]
        public string Name { get; set; }
        public List<AdminGenreViewModel> Genres { get; set; }
    }

    public class AdminGenreViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; } //Her türde kaç tane film bilgisi varsa onu göstermek için
    }

    public class AdminEditGenreViewModel
    {
        public int GenreId { get; set; }

        [Required(ErrorMessage ="Tür bilgisi girmelisiniz!")]
        public string Name { get; set; }
        public List<AdminMovieViewModel> Movies { get; set; } //Her türde kaç tane film bilgisi varsa onu göstermek için
    }
}
