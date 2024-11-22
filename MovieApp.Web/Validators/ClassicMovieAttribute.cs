using MovieApp.Web.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Validators
{
    public class ClassicMovieAttribute : ValidationAttribute
    {
        public ClassicMovieAttribute(int year)
        {
            Year = year;
        }
        public int Year { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (AdminCreateMovieViewModel)validationContext.ObjectInstance;
            var releaseYear = ((DateTime)value).Year;

            if(movie.IsClassic && releaseYear > Year)
            {
                return new ValidationResult($"Klasik filmler için {Year} ve öncesi değer girmelisiniz!");
            }
            return ValidationResult.Success;
        }
    }
}
