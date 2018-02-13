using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> _movies = new List<Movie>()
        {
            new Movie { Id = 0, Name = "Shrek" },
            new Movie { Id = 1, Name = "Wall-E" },
            new Movie { Id = 2, Name = "Inception" },
        };


        // GET: Movies
        public ActionResult Index()
        {
            var moviesViewModel = new MoviesViewModel()
            {
                Items = _movies
            };

            return View(moviesViewModel);
        }

        public ActionResult Details()
        {
            throw new NotImplementedException();
        }


        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!", ReleaseYear = 2001 };

            var customers = new List<Customer>()
            {
                new Customer{ Name = "Customer 1"},
                new Customer{ Name = "Customer 2"},
                new Customer{ Name = "Customer 3"},
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id) => Content($"Id: {id}");

        //public ActionResult Index(int pageIndex = 1, string sortBy = "Name") => Content($"pageIndex={pageIndex}&sortBy={sortBy}");

        [Route(@"movies/released/{year:regex(\d{4})}/{month:range(1, 12)}")]
        public ActionResult ByReleaseYear(int year, int month) => Content($"Year:{year}, month: {month}");
    }
}