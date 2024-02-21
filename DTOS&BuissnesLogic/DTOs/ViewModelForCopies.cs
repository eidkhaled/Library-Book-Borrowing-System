using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS_BuissnesLogic.DTOs
{
    public class ViewModelForCopies
    {
        public int CopyId { get; set; }
        public int? BookID { get; set; }
        
        public int NumberOfCopies { get; set; }
        public string? Status { get; set; } 
    }
}
