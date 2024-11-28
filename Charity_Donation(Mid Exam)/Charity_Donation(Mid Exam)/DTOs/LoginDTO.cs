using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Charity_Donation_Mid_Exam_.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public int Role { get; set; }
    }
}