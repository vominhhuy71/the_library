using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace library.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public GenreDto Genre { get; set; }

        public byte GenreId { get; set; }

        public DateTime DayAdded { get; set; }

        public DateTime ReleaseDay { get; set; }

        public byte NumberInStock { get; set; }
    }
}