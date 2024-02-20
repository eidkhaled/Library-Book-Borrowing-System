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
        
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        [Required]
        public string ISBN { get; set; } = "";
        public DateTime PublicationYear { get; set; }
    }
}
