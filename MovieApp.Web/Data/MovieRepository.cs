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
                new Movie{MovieId=1, Title = "Film 1", Description= "Aciklama 1", Director="Yönetmen 1", Players=new string[] {"Oyuncu1", "Oyuncu2", "Oyuncu3"}, ImageUrl = "1.jpg", GenreId = 1},
                new Movie{MovieId=2, Title = "Film 2", Description= "Aciklama 2", Director="Yönetmen 2", Players=new string[] {"Oyuncu1", "Oyuncu2", "Oyuncu3"}, ImageUrl = "2.jpg", GenreId = 2},
                new Movie{MovieId=3, Title = "Film 3", Description= "Aciklama 3", Director="Yönetmen 3", Players=new string[] {"Oyuncu1", "Oyuncu2", "Oyuncu3"}, ImageUrl = "3.jpg", GenreId = 4},
                new Movie{MovieId=4, Title = "Film 4", Description= "Aciklama 4", Director="Yönetmen 4", Players=new string[] {"Oyuncu1", "Oyuncu2", "Oyuncu3"}, ImageUrl = "1.jpg", GenreId = 3},
                new Movie{MovieId=5, Title = "Film 5", Description= "Aciklama 5", Director="Yönetmen 5", Players=new string[] {"Oyuncu1", "Oyuncu2", "Oyuncu3"}, ImageUrl = "2.jpg", GenreId = 1},
                new Movie{MovieId=6, Title = "Film 6", Description= "Aciklama 6", Director="Yönetmen 6", Players=new string[] {"Oyuncu1", "Oyuncu2", "Oyuncu3"}, ImageUrl = "3.jpg", GenreId = 2}
            };
        }

        public static List<Movie> Movies
        {
            get { return _movies; }
        }

        public static void Add(Movie movie)
        {
            movie.MovieId = _movies.Count() + 1;
            _movies.Add(movie);
        }

        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(x => x.MovieId == id);
        }

        public static void Edit(Movie m)
        {
            foreach (var movie in _movies) 
            {
                if(movie.MovieId == m.MovieId)
                {
                    movie.Title = m.Title;
                    movie.Description = m.Description;
                    movie.Director = m.Director;
                    movie.ImageUrl = m.ImageUrl;
                    movie.GenreId = m.GenreId;
                    break;
                }
            }
        }
    }
}
