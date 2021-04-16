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
            //var books = _context.Books.Include(b => b.Genre).ToList();
            //return View(books);
            if (User.IsInRole(RoleName.CanManageBook))
                return View("List");
            return View("ReadOnlyList");
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

        [Authorize(Roles = RoleName.CanManageBook)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new BookFormViewModel
            {
                //From here book.Id = 0 will be pass to Save()
                Genres = genres,
            };
            return View("BookForm", viewModel);
        }
        [Authorize(Roles = RoleName.CanManageBook)]
        public ActionResult Edit(int id) 
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if(book == null)
            {
                return HttpNotFound();
            };

            var viewModel = new BookFormViewModel(book)
            {               
                Genres = _context.Genres.ToList()
            };
            return View("BookForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageBook)]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel(book)
                {                 
                    Genres = _context.Genres.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            //Create New
            if (book.Id == 0)
            {
                book.DayAdded = DateTime.Now;
                _context.Books.Add(book);
            }
            //Edit
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