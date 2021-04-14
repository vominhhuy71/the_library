using library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace library.ViewModels
{
    public class RandomBookViewModel
    {
        public Book Book { get; set; }
        public List<Customer> Customers { get; set; }
    }
}