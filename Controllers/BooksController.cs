using library.Models;
using library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace library.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            var books = GetBooks();
            return View(books);
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