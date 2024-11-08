using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Form_validation.Models
{
    public class student
    {
        //Name validation
        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-z.-]+$", ErrorMessage = "Name must contain only alphabets")]
        public string Name { get; set; }

        //ID validation
        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "Id must follow XX-XXXXX-X where X is number")]
        public string ID { get; set; }

        //Email validation
        [Required]
        [customEmail]
        public string Email { get; set; }

        //Date validation
        [Required]
        [customDOB]
        public string Date { get; set; }
    }
}