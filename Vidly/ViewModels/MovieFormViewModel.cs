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

        public string Title { get; set; }

        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genres => _context.Genres;
    }
}