using MovieApp.Web.Model;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;

        static MovieRepository()
        {
            _movies = new List<Movie>() {
                new Movie{MovieId=1, Title = "Film 1", Description= "Aciklama 1", Director="Yönetmen 1", Players=new string[] {"Oyuncu1", "Oyuncu2", "Oyuncu3"}, ImageUrl = "1.jpg"},
                new Movie{MovieId=2, Title = "Film 2", Description= "Aciklama 2", Director="Yönetmen 2", Players=new string[] {"Oyuncu1", "Oyuncu2", "Oyuncu3"}, ImageUrl = "2.jpg"},
                new Movie{MovieId=3, Title = "Film 3", Description= "Aciklama 3", Director="Yönetmen 3", Players=new string[] {"Oyuncu1", "Oyuncu2", "Oyuncu3"}, ImageUrl = "3.jpg"}
            };
        }

        public static List<Movie> Movies
        {
            get { return _movies; }
        }

        public static void Add(Movie movie)
        {
            _movies.Add(movie);
        }

        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(x => x.MovieId == id);
        }
    }
}
