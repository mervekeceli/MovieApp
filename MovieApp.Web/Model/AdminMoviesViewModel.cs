using MovieApp.Web.Entity;
using System.Collections.Generic;

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
}
