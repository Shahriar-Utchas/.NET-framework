using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string commentText { get; set; }
        public string CommentBy { get; set; }
        public int postID { get; set; }

    }
}
