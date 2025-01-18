using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CategoryRepo : RepoDB, IRepo<Category, int, bool>
    {
        public bool Add(Category obj)
        {
            db.Categories.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            db.Categories.Remove(db.Categories.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public bool GetByID(int id)
        {
            var data = db.Categories.Find(id) ;
            return true;
        }

        public bool Update(Category obj)
        {
            var exobj = db.Categories.Find(obj.CategoryId);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;

        }
    }
}
