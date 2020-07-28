using BookboxData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bookbox.Models.Books
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Synopsis { get; set; }

        [Required]
        [DisplayName("Author")]
        public int AuthorId { get; set; }

        [DisplayName("Author Name")]
        public string AuthorName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [DisplayName("Image URL")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please Select a Category")]
        [DisplayName("Categories")]
        public IList<int> CategoryIds { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Pubished Date")]
        public DateTime PublishedDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
        public BookModel()
        {
            AddedDate = DateTime.Now;
        }
    }
}
