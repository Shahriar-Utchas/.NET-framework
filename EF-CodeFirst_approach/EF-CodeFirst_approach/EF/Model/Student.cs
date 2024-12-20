using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF_CodeFirst_approach.EF.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        [ForeignKey("Dept")]
        public int DeptID { get; set; }
        public virtual Department Dept { get; set; }
    }
}