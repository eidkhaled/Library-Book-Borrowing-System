using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = "";
        public string AuthorBio { get; set; } = "";
        public ICollection<BookAuthor?> Books { get; set; }
    }
}
