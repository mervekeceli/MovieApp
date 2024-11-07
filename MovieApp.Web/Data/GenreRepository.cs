﻿using MovieApp.Web.Model;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Data
{
    public class GenreRepository
    {
        private static readonly List<Genre> _genres = null;

        static GenreRepository()
        {
            _genres = new List<Genre>() {
                new Genre{GenreId= 1, Name="Macera"},
                new Genre{GenreId= 2, Name="Komedi"},
                new Genre{GenreId= 3, Name="Romantik"},
                new Genre{GenreId= 4, Name="Bilim Kurgu"},
                new Genre{GenreId= 5, Name="Aksiyon"},
            };
        }

        public static List<Genre> Genres { get { return _genres; } }

        public static void Add(Genre genre)
        {
            _genres.Add(genre);
        }

        public static Genre GetById(int id)
        {
            return _genres.FirstOrDefault(g => g.GenreId == id);
        }
    }
}