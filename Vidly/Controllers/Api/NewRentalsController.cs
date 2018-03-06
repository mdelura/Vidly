using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET api/<controller>
        public IEnumerable<Rental> Get() => _context.Rentals;

        // GET api/<controller>/5
        public Rental Get(int id) => _context.Rentals.SingleOrDefault(r => r.Id == id);

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);

            var rentedMovies = _context.Movies
                .Where(m => newRentalDto.MovieIds.Contains(m.Id))
                .ToList();

            foreach (var movie in rentedMovies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}