using System;
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
        public ActionResult Index()
        {
            return View(_context.Movies.Include(m => m.Genre));
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movie != null)
                return View(movie);

            return HttpNotFound();
        }

        [Route(@"movies/released/{year:regex(\d{4})}/{month:range(1, 12)}")]
        public ActionResult ByReleaseYear(int year, int month) => Content($"Year:{year}, month: {month}");
    }
}