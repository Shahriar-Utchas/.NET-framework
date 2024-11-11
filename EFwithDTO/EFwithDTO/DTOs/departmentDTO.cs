using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFwithDTO.DTOs
{
    public class departmentDTO
    {
        public int ID { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
    }
}