﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// POCOs
/// </summary>
namespace library.Models
{
    public class Book
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public DateTime ReleaseDay { get; set; }

        public DateTime DayAdded { get; set; }

        public int NumberInStock { get; set; }

    }
}