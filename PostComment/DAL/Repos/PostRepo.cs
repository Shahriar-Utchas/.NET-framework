using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PostRepo : RepoDB, IRepo<Post, int, Post>
    {
        public Post Create(Post obj)
        {
            db.Posts.Add(obj);
            db.SaveChanges();
            return obj;

        }

        public Post Delete(int id)
        {
            var post = db.Posts.Find(id);
            if (post != null)
            {
                db.Posts.Remove(post);
                db.SaveChanges();
                return post;
            }
                return null;
            }

        public Post Read(int id)
        {
            return db.Posts.Find(id);
        }
        public List<Post> ReadAll()
        {
            return db.Posts.ToList();
        }

        public Post Update(Post obj)
        {
            var post = db.Posts.Find(obj.Id);
            if (post != null)
            {
               db.Entry(post).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;

            }
            return null;
        }
    }
}
