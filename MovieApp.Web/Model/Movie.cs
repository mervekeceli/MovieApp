using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Model
{
    public class Movie
    {
        public int MovieId { get; set; }

        [DisplayName("Başlık")]
        [Required(ErrorMessage = "Film Başlığı Boş Olamaz!")] // Zorunlu alan
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Film Başlığı 2-50 Karakter Arasında Olmalıdır!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Film Açıklaması Eklemelisiniz!")]
        public string Description { get; set; }
        public string Director { get; set; }
        public string[] Players { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int? GenreId { get; set; }
    }
}
