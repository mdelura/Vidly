using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Movies
        public ActionResult Index() => View(User.IsInRole(RoleName.CanManageMovies) ? ViewNames.List : ViewNames.ReadOnlyList);

        public ActionResult Details(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movie != null)
                return View(movie);

            return HttpNotFound();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New() => View(ViewNames.MovieForm, new MovieFormViewModel("New Movie", new Movie()));

        public ActionResult Edit(int id)
        {
            var customer = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(ViewNames.MovieForm, new MovieFormViewModel("Edit Movie", customer));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        static class ViewNames
        {
            public const string MovieForm = "MovieForm";
            public const string List = "List";
            public const string ReadOnlyList = "ReadOnlyList";

        }
    }
}