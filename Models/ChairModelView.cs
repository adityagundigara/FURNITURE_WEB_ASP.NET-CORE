﻿using System.ComponentModel.DataAnnotations;

namespace FURNITURE_WEB.Models
{
    public class ChairModelView
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImagePath { get; set; }
    }
}
