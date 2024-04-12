﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS_BuissnesLogic.DTOs
{
    public class ViewModelForCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } 
        public int? ParentCategoryId { get; set; } 
        public string? ParentCategoryName { get; set; }
        public List<ViewModelForCategory>? Children { get; set; }

    }
}
