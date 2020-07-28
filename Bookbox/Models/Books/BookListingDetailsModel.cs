using BookboxData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookbox.Models.Books
{
    public class BookListingDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublishedDate { get; set; }
        public decimal Price { get; set; }
        public string Synopsis { get; set; }
        public string ImageUrl { get; set; }
        public IList<Category> Categories { get; set; }
    }
}
