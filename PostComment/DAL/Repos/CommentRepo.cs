using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CommentRepo : RepoDB, IRepo<Comment, int, Comment>
    {
        public Comment Create(Comment obj)
        {
            db.Comments.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public Comment Delete(int id)
        {
            var comment = db.Comments.Find(id);
            if (comment != null)
            {
                db.Comments.Remove(comment);
                db.SaveChanges();
                return comment;
            }
            return null;
        }
        public List<Comment> ReadAll()
        {
            return db.Comments.ToList();
        }

        public Comment Read(int id)
        {
            return db.Comments.Find(id);
        }

        public Comment Update(Comment obj)
        {
            var comment = db.Comments.Find(obj.Id);
            if (comment != null)
            {
                db.Entry(comment).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            return null;
        }
    }
}
