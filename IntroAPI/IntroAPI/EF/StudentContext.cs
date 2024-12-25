using IntroAPI.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IntroAPI.EF
{
    public class StudentContext : DbContext
    {
        public DbSet <Student> students { get; set; }
    }
}