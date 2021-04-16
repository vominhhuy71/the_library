using library.Dtos;
using library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace library.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        public ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);

            var books = _context.Books.Where(m => newRentalDto.BookIds.Contains(m.Id)).ToList();
            foreach (var book in books)
            {
                if(book.NumberAvailable == 0)
                {
                    return BadRequest("Book is not available");
                };
                book.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Book = book,
                    DayRented = DateTime.Now                   
                };

                _context.Retals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
