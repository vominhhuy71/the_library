using AutoMapper;
using library.Dtos;
using library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace library.Controllers.Api
{
    public class BooksController : ApiController
    {
        public ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/books
        public IHttpActionResult GetBooks()
        {
            var bookDtos = _context.Books
                .Include(b=>b.Genre)
                .ToList()
                .Select(Mapper.Map<Book, BookDto>);
            return Ok(bookDtos);
        }

        //GET /api/books/{id}
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Book, BookDto>(book));
        }

        //POST /api/books
        [HttpPost]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var book = Mapper.Map<BookDto, Book>(bookDto);
            book.DayAdded = DateTime.Now;
            _context.Books.Add(book);
            _context.SaveChanges();
            bookDto.Id = book.Id;
            return Created(new Uri(Request.RequestUri + "/" + book.Id), bookDto);
        }

        //PUT /api/books/{id}
        [HttpPut]
        public IHttpActionResult UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var bookInDb = _context.Books.SingleOrDefault(c => c.Id == id);
            if (bookInDb == null)
            {
                return NotFound();
            }

            Mapper.Map<BookDto, Book>(bookDto, bookInDb);

            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var bookInDb = _context.Books.SingleOrDefault(c => c.Id == id);
            if (bookInDb == null)
            {
                return NotFound();
            }
            _context.Books.Remove(bookInDb);

            _context.SaveChanges();

            return Ok();
        }
    }
}
