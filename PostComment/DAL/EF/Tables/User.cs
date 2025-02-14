using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class User
    {
        [Key]
        public string Uname { get; set; }
        public string password { get; set; }
        public string Type { get; set; }

    }
}
