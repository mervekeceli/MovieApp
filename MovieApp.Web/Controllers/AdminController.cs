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
using System.Threading.Tasks;

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
                GenreIds = m.Genres.Select(x => x.GenreId).ToArray()
            }).FirstOrDefault(m => m.MovieId == id);

            ViewBag.Genres = _context.Genres.ToList();

            if (entity == null)
                return NotFound();

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> MovieUpdate(AdminEditMovieViewModel model, int[] GenreIds, IFormFile file)
        {
            if (ModelState.IsValid)
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
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                entity.Genres = GenreIds.Select(id => _context.Genres.FirstOrDefault(i => i.GenreId == id)).ToList();
                _context.SaveChanges();

                return RedirectToAction("MovieList");
            }
            ViewBag.Genres = _context.Genres.ToList();
            return View(model);
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

        public IActionResult MovieCreate()
        {
            ViewBag.Genres = _context.Genres.ToList();
            return View(new AdminCreateMovieViewModel());
        }

        [HttpPost]
        public IActionResult MovieCreate(AdminCreateMovieViewModel model)
        {
            //if (model.GenreIds == null)
            //{
            //    ModelState.AddModelError("GenreIds", "En az bir tür seçmelisiniz!");
            //}

            if (ModelState.IsValid)
            {
                var entity = new Movie
                {
                    Title = model.Title,
                    Description = model.Description,
                    ImageUrl = "no-image.png"
                };

                foreach (var id in model.GenreIds)
                {
                    entity.Genres.Add(_context.Genres.FirstOrDefault(g => g.GenreId == id));
                }

                _context.Movies.Add(entity);
                _context.SaveChanges();
                return RedirectToAction("MovieList", "Admin");
            }
            ViewBag.Genres = _context.Genres.ToList();
            return View(model);
        }

        public IActionResult GenreList()
        {
            return View(GetGenres());
        }

        private AdminGenresViewModel GetGenres()
        {
            return new AdminGenresViewModel
            {
                Genres = _context.Genres.Select(g => new AdminGenreViewModel
                {
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Count = g.Movies.Count
                }).ToList()
            };
        }

        [HttpGet]
        public IActionResult GenreUpdate(int? id)
        {
            if (id == null)
                return NotFound();

            var entity = _context.Genres
                .Select(g => new AdminEditGenreViewModel
                {
                    GenreId = g.GenreId,
                    Name = g.Name,
                    Movies = g.Movies.Select(x => new AdminMovieViewModel
                    {
                        MovieId = x.MovieId,
                        Title = x.Title,
                        ImageUrl = x.ImageUrl,
                    }).ToList()
                })
                .FirstOrDefault(g => g.GenreId == id);

            if (entity == null)
                return NotFound();

            return View(entity);
        }

        [HttpPost]
        public IActionResult GenreUpdate(AdminEditGenreViewModel model, int[] MovieIds)
        {
            var entity = _context.Genres.Include("Movies").FirstOrDefault(x => x.GenreId == model.GenreId);
            if (entity == null)
                return NotFound();

            entity.Name = model.Name;
            foreach (var id in MovieIds)
            {
                entity.Movies.Remove(entity.Movies.FirstOrDefault(m => m.MovieId == id));
            }
            _context.SaveChanges();

            return RedirectToAction("GenreList");
        }

        [HttpPost]
        public IActionResult GenreDelete(int genreId)
        {
            var entity = _context.Genres.Find(genreId);

            if (entity != null)
            {
                _context.Genres.Remove(entity);
                _context.SaveChanges();
            }
            return RedirectToAction("GenreList");
        }

        [HttpPost]
        public IActionResult GenreCreate(AdminGenresViewModel model)
        {
            if(model.Name != null && model.Name.Length < 3)
            {
                ModelState.AddModelError("Name", "Tür adı minumum 3 karakterli olmalıdır!");
            }
            if (ModelState.IsValid)
            {
                _context.Genres.Add(new Genre
                {
                    Name = model.Name,
                });
                _context.SaveChanges();

                return RedirectToAction("GenreList");
            }
            return View("GenreList", GetGenres());
        }
    }
}
