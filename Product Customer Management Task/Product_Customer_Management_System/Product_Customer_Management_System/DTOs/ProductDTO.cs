using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Product_Customer_Management_System.DTOs
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        [Required]
        public string Category { get; set; }
    }
}