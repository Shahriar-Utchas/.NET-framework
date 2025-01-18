using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProductRepo : RepoDB, IRepo<Product, int, Product> , IProductFeatures
    {
        public Product Add(Product obj)
        {
            db.Products.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var obj = db.Products.Find(id);
            db.Products.Remove(obj);
            return db.SaveChanges() > 0;
            
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();

        }

        public Product GetByID(int id)
        {
            return db.Products.Find(id);
        }

        public List<Product> GetProductsByCategory(int id)
        {
            return db.Products.Where(x => x.CategoryId == id).ToList();
        }

        public Product Update(Product obj)
        {
            var exobj = db.Products.Find(obj.ProductId);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;
        }
    }
}
