using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TRP_Management_System.EF;
using TRP_Management_System.Models;

namespace TRP_Management_System.DTOs
{
    public class ProgramDTO
    {
        public int ProgramId { get; set; }
        [StringLength(150,ErrorMessage = "Name must be less than 150 characters")]
        [ProgramUniqueName]
        public string ProgramName { get; set; }

        [Required(ErrorMessage = "TRP Score is required")]
        public decimal TRPScore { get; set; }
        public int ChannelId { get; set; }
        [Required(ErrorMessage = "Air Time is required")]
        public System.TimeSpan AirTime { get; set; }

        public virtual Channel Channel { get; set; }
    }
}