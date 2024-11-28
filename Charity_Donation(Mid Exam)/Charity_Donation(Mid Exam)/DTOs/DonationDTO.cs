using Charity_Donation_Mid_Exam_.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Charity_Donation_Mid_Exam_.DTOs
{
    public class DonationDTO
    {
        public int DonorID { get; set; }
        [Required]
        public double Amount { get; set; }
        public System.DateTime Date { get; set; }
        public int CampainID { get; set; }

        public virtual CampainInfo CampainInfo { get; set; }
    }
}