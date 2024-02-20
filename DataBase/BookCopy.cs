using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public enum StatusAvailable { Available, NotAvailable }
    public class BookCopy
    {
        [Key]
        public int CopyId { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int NumberOfCopies {  get; set; }
        public string Status { get; set; }=StatusAvailable.Available.ToString();

    }
}
