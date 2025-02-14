using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Comment
    {
        public int Id { get; set; }
        public string commentText { get; set; }
        [ForeignKey("User")]
        public string CommentBy { get; set; }
        [ForeignKey("Post")]
        public int postID { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }

    }
}
