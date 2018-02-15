using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public MovieFormViewModel()
        {
        }

        public MovieFormViewModel(string title) : this(title, null)
        {
        }

        public MovieFormViewModel(Movie movie) : this(null, movie)
        {
        }

        public MovieFormViewModel(string title, Movie movie)
        {
            Title = title;
            Movie = movie;
        }

        public string Title { get; set; }

        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genres => _context.Genres;
    }
}