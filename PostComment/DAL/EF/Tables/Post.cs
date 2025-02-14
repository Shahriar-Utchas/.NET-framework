using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey("User")]
        public string PostedBy { get; set; } 

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public Post()
        {
            Comments = new List<Comment>();
        }

    }
}
