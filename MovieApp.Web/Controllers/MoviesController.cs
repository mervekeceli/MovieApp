﻿using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Data;
using MovieApp.Web.Model;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //localhost:5000/movies/list
        //localhost:5000/movies/list/1
        [HttpGet]
        public IActionResult List(int? id, string q)
        {
            var movies = MovieRepository.Movies;
            if (id != null)
            {
                movies = movies.Where(x=> x.GenreId == id).ToList();
            }

            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(m => m.Title.ToLower().Contains(q.ToLower()) || 
                m.Description.ToLower().Contains(q.ToLower())).ToList();
            }

            var model = new MoviesViewModel()
            {
                Movies = movies
            };

            return View("Movies",model);
        }


        //localhost:5000/movies/details
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(MovieRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            //Model Binding
            MovieRepository.Add(movie);

            return RedirectToAction("List"); // Action'a yönlendirme
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(MovieRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie movie) 
        {
            MovieRepository.Edit(movie);
            // /movies/details/1
            return RedirectToAction("Details","Movies",new {@id = movie.MovieId});
        }

    }
}
