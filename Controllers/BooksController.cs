using library.Models;
using library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace library.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        private ApplicationDbContext _context { get; set; }

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var books = _context.Books.Include(b => b.Genre).ToList();
            return View(books);
        }

        public ActionResult Details(int id)
        {
            var book = _context.Books.Include(b => b.Genre).SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //GET: Books/Random
        public ActionResult Random()
        {
            var book = new Book() {Name = "Book 1"};

            //ViewData dictionary
            //ViewData["Book"] = book;
            //ViewBag 
            //ViewBag.Book = book;

            var customer = new List<Customer>
            {
                new Customer {Name="Customer 1"},
                new Customer {Name="Customer 2"},
            };

            var viewModel = new RandomBookViewModel
            {
                Book = book,
                Customers = customer,
            };

            return View(viewModel);
        }

        private IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book {Id = 1, Name = "Book 1"},
                new Book {Id = 2, Name = "Book 2"},
            };
        }

    }
}