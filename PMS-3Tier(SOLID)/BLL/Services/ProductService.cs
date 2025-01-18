using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<Product, ProductCategoryDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
            });
            return new Mapper(config);

        }
        public static ProductCategoryDTO Add(ProductCategoryDTO product) {
            var repo = DataAccessFactory.getProduct();
            var addedProduct = repo.Add(GetMapper().Map<Product>(product));
            return GetMapper().Map<ProductCategoryDTO>(addedProduct);

            //return repo.Add(GetMapper().Map<ProductCategoryDTO>(product);)
        }
        public static List<ProductDTO> GetProducts()
        {
            var repo = DataAccessFactory.getProduct();
            return GetMapper().Map<List<ProductDTO>>(repo.GetAll());
        }
        public static ProductDTO GetProduct(int id)
        {
            var repo = DataAccessFactory.getProduct();
            return GetMapper().Map<ProductDTO>(repo.GetByID(id));
        }
        public static bool DeleteProduct(int id)
        {
            var repo = DataAccessFactory.getProduct();
            return repo.Delete(id);
        }
        public static ProductDTO UpdateProduct(ProductDTO product)
        {
            var repo = DataAccessFactory.getProduct();
            return GetMapper().Map<ProductDTO>(repo.Update(GetMapper().Map<Product>(product)));
        }
        public static List<ProductDTO> GetProductsByCategory(int id)
        {
            var repo = DataAccessFactory.getProductFeatures();
            return GetMapper().Map<List<ProductDTO>>(repo.GetProductsByCategory(id));
        }
    }

}
