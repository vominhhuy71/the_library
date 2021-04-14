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
        public ActionResult Index(int? pageIndex=1, string sortBy="Name")
        {

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
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

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        [Route("books/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDay (int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}