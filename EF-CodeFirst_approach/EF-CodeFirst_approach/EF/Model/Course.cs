using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF_CodeFirst_approach.EF.Model
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        [ForeignKey("Dept")]
        public int DeptId { get; set; }
        public virtual Department Dept { get; set; }
    }
}