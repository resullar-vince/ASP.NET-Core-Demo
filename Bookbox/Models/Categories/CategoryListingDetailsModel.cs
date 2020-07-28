using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookbox.Models.Categories
{
    public class CategoryListingDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddedDate { get; set; }
    }
}
