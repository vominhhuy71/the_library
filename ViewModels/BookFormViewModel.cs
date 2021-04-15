using library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace library.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        [Display(Name = "Release Day")]
        [Required]
        public DateTime? ReleaseDay { get; set; }

        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int? NumberInStock { get; set; }


        public string Title
        {
            get
            {
                if(Id != 0)
                {
                    return "Edit Book";
                }
                return "New Book";
            }
        }
        public BookFormViewModel()
        {
            Id = 0;
        }

        public BookFormViewModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            ReleaseDay = book.ReleaseDay;
            NumberInStock = book.NumberInStock;
            GenreId = book.GenreId;
        }
    }
}