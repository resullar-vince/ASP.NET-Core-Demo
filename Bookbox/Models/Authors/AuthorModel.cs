using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BookboxData.Models;

namespace Bookbox.Models.Authors
{
    public class AuthorListModel
    {
        public IEnumerable<AuthorModel> AuthorList { get; set; }
    }
    public class AuthorModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        public string FullName 
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        [EmailAddress]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Added Date")]
        public DateTime AddedDate { get; set; }

        public IList<Book> Books { get; set; }
    }
}
