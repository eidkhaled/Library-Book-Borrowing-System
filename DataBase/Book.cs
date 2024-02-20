using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        [Required]
        public string ISBN { get; set; } = "";
        public DateTime PublicationYear { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<BookAuthor?> Author { get; set; }
    }
}
