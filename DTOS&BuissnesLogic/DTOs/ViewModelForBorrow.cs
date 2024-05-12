using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS_BuissnesLogic.DTOs
{
    public class ViewModelForBorrow
    {
        public int? borrowId { get; set; }
        public int bookId { get; set; }
        public string borrowerName { get; set; }
        public string borrowerAddress { get; set; }
        public string phoneNumber { get; set; }
        public int? AvailbleCopies { get; set; }
        public int? ActiveCopies { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; } 
    }
}
