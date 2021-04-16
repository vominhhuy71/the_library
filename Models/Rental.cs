using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace library.Models
{
    public class Rental
    {
        public int Id { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Book Book { get; set; }

        public DateTime DayRented { get; set; }

        public DateTime? DayReturned { get; set; }
    }
}