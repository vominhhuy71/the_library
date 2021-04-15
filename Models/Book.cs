using System;
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

        public Genre Genre { get; set; }
        [Required]
        [Display(Name ="Genre")]
        public int GenreId { get; set; }

        [Display(Name="Release Day")]
        [Required]
        public DateTime ReleaseDay { get; set; }

        [Display(Name="Day added")]
        public DateTime DayAdded { get; set; }
        [Range(1,20)]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

    }
}