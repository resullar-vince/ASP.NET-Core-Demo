using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookboxData.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }
        public string Synopsis { get; set; }
        public string ImageUrl { get; set; }

        [Required]
        public Author Author { get; set; }

        [Required]
        public ICollection<BookCategory> BookCategories { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; private set; }
        public Book()
        {
            UpdatedDate = DateTime.Now;
        }
    }
}
