using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Category,int,bool> getCategory()
        {
            return new CategoryRepo();
        }
        public static IRepo<Product, int, Product> getProduct()
        {
            return new ProductRepo();
        }
        public static IProductFeatures getProductFeatures()
        {
            return new ProductRepo();
        }
    }
}
