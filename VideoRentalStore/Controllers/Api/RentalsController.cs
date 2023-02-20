using System;
using System.Linq;
using System.Web.Http;
using VideoRentalStore.Models;
using VideoRentalStore.Models.Dtos;

namespace VideoRentalStore.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // POST : /api/rentals
        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto rentalDto)
        {
            // in the case when we build a private API  we can remove these noisy checking but in the case of public API  we need to use them : 
            /*
            if (rentalDto.MovieIds.Count == 0)
            {
                return BadRequest("No movie ids have been given.");
            }
            if (rentalDto.CustomerId.GetType().Name != "Int32")
            {
                return BadRequest("CustomerId is not valid.");
            }
            */
            var customer = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);
            /*
            if (customer == null)
            {
                return BadRequest("CustomerId is not found.");
            }
            */
            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();
            /*
            if (movies.Count != rentalDto.MovieIds.Count)
            {
                return BadRequest("One or more MovieIds are invalid.");
            }
            */
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available.");
                }
                movie.NumberAvailable--;
                var rental = new Rental()
                {
                    DateRented = DateTime.Now,
                    Customer = customer,
                    Movie = movie
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
