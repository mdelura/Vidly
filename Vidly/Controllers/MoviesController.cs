﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Movies
        public ActionResult Index() => View(_context.Movies.Include(m => m.Genre));

        public ActionResult Details(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movie != null)
                return View(movie);

            return HttpNotFound();
        }

        public ActionResult New() => View(ViewNames.MovieForm, new MovieFormViewModel() { Title = "New Movie" });

        public ActionResult Edit(int id)
        {
            var customer = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Title = "Edit Movie",
                Movie = customer,
            };

            return View(ViewNames.MovieForm, viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [Route(@"movies/released/{year:regex(\d{4})}/{month:range(1, 12)}")]
        public ActionResult ByReleaseYear(int year, int month) => Content($"Year:{year}, month: {month}");

        class ViewNames
        {
            public const string MovieForm = "MovieForm";

        }
    }
}