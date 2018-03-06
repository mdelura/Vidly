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
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);

            var rentedMovies = _context.Movies
                .Where(m => newRentalDto.MovieIds.Contains(m.Id));

            foreach (var movie in rentedMovies)
            {
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

        [HttpPut]
        // PUT api/<controller>/5
        public void Put(int id, NewRentalDto newRentalDto)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}