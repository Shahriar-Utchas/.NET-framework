using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TRP_Management_System.DTOs
{
    public class loginDTO
    {
        [Required]
        public string User { get; set; }
        [Required]
        public string Pass { get; set; }
        public int Role { get; set; }
    }
}