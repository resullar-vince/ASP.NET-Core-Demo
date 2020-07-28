using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookbox.Models.Books
{
    public class BookListModel
    {
        public IEnumerable<BookListingDetailsModel> BookList { get; set; }
    }
}
