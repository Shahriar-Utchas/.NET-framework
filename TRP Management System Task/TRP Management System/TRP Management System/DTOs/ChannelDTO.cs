using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TRP_Management_System.Models;

namespace TRP_Management_System.DTOs
{
    public class ChannelDTO
    {
        public int ChannelId { get; set; }
        [StringLength(100, ErrorMessage = "Name must be less than 100 characters")]
        [ChannelUniqueName]
        public string ChannelName { get; set; }

        [ChannelYearValidation]
        public int EstablishYear { get; set; }

        [Required(ErrorMessage = "Please Enter Country")]
        [StringLength(50, ErrorMessage = "Country must be less than 50 characters")]
        public string Country { get; set; }
    }
}
