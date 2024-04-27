using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class BorrowingRecords
    {
        [Key]
        public int borrowId { get; set; }
        public int bookId {  get; set;}
        public string? borrowerName { get; set; }
        public string? borrowerAddress { get; set; }
        public string? phoneNumber { get; set; }
        public Book? book {  get; set;}
        public DateTime BorrowDate { get; set;} = DateTime.Now;
        public DateTime? ReturnDate { get; set; } 



    }
}
