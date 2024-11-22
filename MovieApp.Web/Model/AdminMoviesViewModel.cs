using MovieApp.Web.Entity;
using MovieApp.Web.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Model
{
    public class AdminMoviesViewModel
    {
        public List<Movie> Movies { get; set; }
    }

    public class AdminMovieViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public List<Genre> Genres { get; set; }
    }

    public class AdminCreateMovieViewModel
    {
        [Display(Name = "Film adı")]
        [Required(ErrorMessage ="Film adı girmelisiniz!")]
        [StringLength(50,MinimumLength =2, ErrorMessage ="Film adı için 2-50 karakter girmelisiniz!")]
        public string Title { get; set; }

        [Display(Name = "Film açıklama")]
        [Required(ErrorMessage = "Film açıklama girmelisiniz!")]
        [StringLength(3000, MinimumLength = 10, ErrorMessage = "Film açıklama için 10-3000 karakter girmelisiniz!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "En az bir tür seçmelisiniz!")]
        public int[] GenreIds { get; set; }

        public bool IsClassic { get; set; }

        [ClassicMovie(1950)]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
    }

    public class AdminEditMovieViewModel
    {
        public int MovieId { get; set; }

        [Display(Name = "Film adı")]
        [Required(ErrorMessage = "Film adı girmelisiniz!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Film adı için 2-50 karakter girmelisiniz!")]
        public string Title { get; set; }

        [Display(Name = "Film açıklama")]
        [Required(ErrorMessage = "Film açıklama girmelisiniz!")]
        [StringLength(3000, MinimumLength = 10, ErrorMessage = "Film açıklama için 10-3000 karakter girmelisiniz!")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "En az bir tür seçmelisiniz!")]
        public int[] GenreIds { get; set; }
    }
}
