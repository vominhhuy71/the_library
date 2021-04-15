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

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new BookFormViewModel
            {
                Genres = genres,
            };
            return View("BookForm", viewModel);
        }

        public ActionResult Edit(int id) 
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if(book == null)
            {
                return HttpNotFound();
            };

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = _context.Genres.ToList()
            };
            return View("BookForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Book book)
        {
            if(book.Id == 0)
            {
                book.DayAdded = DateTime.Now;
                _context.Books.Add(book);
            }
            else
            {
                var bookInDb = _context.Books.Single(b => b.Id == book.Id);
                bookInDb.Name = book.Name;
                bookInDb.GenreId = book.GenreId;
                bookInDb.NumberInStock = book.NumberInStock;
                bookInDb.ReleaseDay = book.ReleaseDay;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Books");
        }
    }
}