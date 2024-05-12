using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS_BuissnesLogic.DTOs
{
    public class viewModelForBook
    {
        public int? BookID { get; set; }

        public string Title { get; set; } = "";
        public string? Description { get; set; }
        [Required]
        public string? ISBN { get; set; } 
        public int? CategoryId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Total copies must be greater than 0.")]
        public int? TotalCopies { get; set; }
        public int? AvailbleCopies { get; set; }
        public int? ActiveCopies { get; set; }
        public string? CategoryName { get; set; }
        public DateTime? PublicationYear { get; set; }
    }
}
