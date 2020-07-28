using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookboxData.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public ICollection<Book> Books { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; private set; }
        public Author()
        {
            UpdatedDate = DateTime.Now;
        }
    }
}
