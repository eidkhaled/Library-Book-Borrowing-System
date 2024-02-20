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
        public int BorrowId { get; set; }
        public int CopyType { get; set;}
        public int bookCopyId {  get; set;}
        public BookCopy? bookCopy {  get; set;}
        public DateTime BorrowDate { get; set;}
        public DateTime DueDate { get; set;}
        public DateTime ReturnDate { get; set; } = DateTime.MinValue;



    }
}
