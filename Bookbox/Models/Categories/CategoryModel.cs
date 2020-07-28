using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bookbox.Models.Categories
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Added Date")]
        public DateTime AddedDate { get; set; }
    }
}
