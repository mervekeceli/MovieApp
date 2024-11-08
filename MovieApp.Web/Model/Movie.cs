using System.ComponentModel;

namespace MovieApp.Web.Model
{
    public class Movie
    {
        public int MovieId { get; set; }

        [DisplayName("Başlık")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string[] Players { get; set; }
        public string ImageUrl { get; set; }
        public int GenreId { get; set; }
    }
}
