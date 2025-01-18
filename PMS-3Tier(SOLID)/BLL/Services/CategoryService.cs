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
    public class CategoryService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category,CategoryDTO>();
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<Category, CategoryProductDTO>();
                cfg.CreateMap<Product, ProductDTO>();
            });
            return new Mapper(config);
        }
        public static bool AddCategory(CategoryDTO category)
        {
            var repo = DataAccessFactory.getCategory();
            return repo.Add(GetMapper().Map<Category>(category));
        }

        public static List<CategoryDTO> GetCategories() { 
            
            var repo = DataAccessFactory.getCategory();
            return GetMapper().Map<List<CategoryDTO>>(repo.GetAll());

        }
        public static bool GetCategory(int id)
        {
            var repo = DataAccessFactory.getCategory();
            var data = repo.GetByID(id);
            return true;
        }
        public static bool DeleteCategory(int id)
        {
            var repo = DataAccessFactory.getCategory();
            return repo.Delete(id);
        }
        public static bool UpdateCategory(CategoryDTO category)
        {
            var repo = DataAccessFactory.getCategory();
            return repo.Update(GetMapper().Map<Category>(category));
        }


    }
}
