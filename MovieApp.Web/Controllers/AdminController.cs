using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;
using MovieApp.Web.Entity;
using MovieApp.Web.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieApp.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly MovieContext _context; //Injection işlemi
        public AdminController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieUpdate(int? id)
        {
            if (id == null)
                return NotFound();

            var entity = _context.Movies.Select(m => new AdminEditMovieViewModel
            {
                MovieId = m.MovieId,
                Title = m.Title,
                Description = m.Description,
                ImageUrl = m.ImageUrl,
                SelectedGenres = m.Genres
            }).FirstOrDefault(m => m.MovieId == id);

            ViewBag.Genres = _context.Genres.ToList();

            if (entity == null)
                return NotFound();

            return View(entity);
        }

        [HttpPost]
        public IActionResult MovieUpdate(AdminEditMovieViewModel model, int[] GenreIds, IFormFile file)
        {
            var entity = _context.Movies.Include(g => g.Genres).FirstOrDefault(m => m.MovieId == model.MovieId);
            if (entity == null)
                return NotFound();

            entity.Title = model.Title;
            entity.Description = model.Description;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var fileName = string.Format($"{Guid.NewGuid()}{extension}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", fileName);

                entity.ImageUrl = fileName;
                using(var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }
            }
            entity.Genres = GenreIds.Select(id => _context.Genres.FirstOrDefault(i => i.GenreId == id)).ToList();

            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        public IActionResult MovieList()
        {
            return View(new AdminMoviesViewModel
            {
                Movies = _context.Movies
                .Include(m => m.Genres)
                //.Select(x=> new AdminMovieViewModel
                //{
                //    MovieId = x.MovieId,
                //    Title = x.Title,
                //    ImageUrl = x.ImageUrl,
                //    Genres = x.Genres.ToList()
                //})
                .ToList()
            });
        }

        [HttpPost]
        public IActionResult MovieDelete(int movieId)
        {
            var entity = _context.Movies.Find(movieId);
            if (entity != null)
            {
                _context.Movies.Remove(entity);
                _context.SaveChanges();
            }
            return RedirectToAction("MovieList");
        }

        public IActionResult GenreList()
        {
            return View(new AdminGenresViewModel
            {
                Genres = _context.Genres.Select(g=> new AdminGenreViewModel
                {
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Count = g.Movies.Count
                }).ToList()
            });
        }

        [HttpGet]
        public IActionResult GenreUpdate(int? id)
        {
            if(id == null) 
                return NotFound();

            var entity = _context.Genres
                .Select(g=> new AdminEditGenreViewModel
                {
                    GenreId =g.GenreId,
                    Name = g.Name,
                    Movies = g.Movies.Select(x=> new AdminMovieViewModel
                    {
                        MovieId = x.MovieId,
                        Title = x.Title,
                        ImageUrl = x.ImageUrl,
                    }).ToList()
                })
                .FirstOrDefault(g => g.GenreId ==id);

            if(entity == null)
                return NotFound();

            return View(entity);
        }

        [HttpPost]
        public IActionResult GenreUpdate(AdminEditGenreViewModel model, int[] MovieIds)
        {
            var entity = _context.Genres.Include("Movies").FirstOrDefault(x=>x.GenreId==model.GenreId);
            if(entity == null)
                return NotFound();

            entity.Name = model.Name;
            foreach(var id in MovieIds)
            {
                entity.Movies.Remove(entity.Movies.FirstOrDefault(m=>m.MovieId == id));
            }
            _context.SaveChanges();

            return RedirectToAction("GenreList");
        }

        [HttpPost]
        public IActionResult GenreDelete(int genreId)
        {
            var entity = _context.Genres.Find(genreId);

            if(entity!= null)
            {
                _context.Genres.Remove(entity);
                _context.SaveChanges();
            }
            return RedirectToAction("GenreList");
        }

        public IActionResult MovieCreate()
        {
            ViewBag.Genres = _context.Genres.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieCreate(Movie m, int[] genreIds)
        {
            if(ModelState.IsValid)
            {
                m.Genres = new List<Genre>();
                foreach(var id in genreIds)
                {
                    m.Genres.Add(_context.Genres.FirstOrDefault(g=>g.GenreId == id));
                }

                _context.Movies.Add(m);
                _context.SaveChanges();
                return RedirectToAction("MovieList", "Admin");
            }
            ViewBag.Genres = _context.Genres.ToList();
            return View();
        }
    }
}
