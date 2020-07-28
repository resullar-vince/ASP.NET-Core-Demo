using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookboxData.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; private set; }
        public ICollection<BookCategory> BookCategories { get; set; }

        public Category()
        {
            UpdatedDate = DateTime.Now;
        }
    }
}
