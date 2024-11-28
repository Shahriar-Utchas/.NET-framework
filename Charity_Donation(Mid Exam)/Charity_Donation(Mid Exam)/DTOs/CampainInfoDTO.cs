using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Charity_Donation_Mid_Exam_.DTOs
{
    public class CampainInfoDTO
    {
        public int CampainID { get; set; }
        [Required(ErrorMessage = "Please Enter Campain Name")]
        public string campName { get; set; }
        [Required(ErrorMessage = "Please Enter Campain Description")]
        public string Desc { get; set; }
    }
}