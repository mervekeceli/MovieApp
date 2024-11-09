using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieApp.Web.Entity
{
    public class Movie
    { 
        public int MovieId { get; set; }

        [Required] // Zorunlu alan
        public string Title { get; set; }

        [MaxLength]
        public string Description { get; set; }
        public string Director { get; set; }
        public string ImageUrl { get; set; }

        [Required]
        public int? GenreId { get; set; }
    }
}
