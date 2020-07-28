using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookbox.Models.Categories
{
    public class CategoryListModel
    {
        public IEnumerable<CategoryListingDetailsModel> CategoryList { get; set; }
    }
}
