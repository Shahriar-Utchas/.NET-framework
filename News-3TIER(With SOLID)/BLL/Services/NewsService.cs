using AutoMapper;
using BLL.DTOs;
using DAL.EF.Table;
using DAL.Repos;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL.Services
{
    public class NewsService
    {
        INewsRepo<News, int, string, DateTime> repo = DataAccess.GetNewsRepo();
        public List<NewsDTO> GetAll()
        {
            var data = repo.GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<NewsDTO>>(data);
            return ret;
        }
        public NewsDTO GetByID(int id)
        {
            var data = repo.GetByID(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<NewsDTO>(data);
            return ret;
        }
        public void Create(NewsDTO news)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewsDTO, News>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<News>(news);
            repo.Create(data);
        }
        public String Update(NewsDTO news)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewsDTO, News>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<News>(news);
            return repo.Update(data);
        }
        public void Delete(int id)
        {
            repo.Delete(id);
        }
        public List<NewsDTO> GetByCategory(string category)
        {
            var data = repo.GetByCategory(category);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<NewsDTO>>(data);
            return ret;
        }
        public List<NewsDTO> GetByDate(DateTime date)
        {
            var data = repo.GetByDate(date);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<NewsDTO>>(data);
            return ret;
        }
        public List<NewsDTO> GetByTitle(string title)
        {
            var data = repo.GetByTitle(title);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<NewsDTO>>(data);
            return ret;
        }
        public List<NewsDTO> GetByDateCategory(DateTime date, string category)
        {
            var data = repo.GetByDateCategory(date, category);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<NewsDTO>>(data);
            return ret;
        }
        public List<NewsDTO> GetByDateTitle(DateTime date, string title)
        {
            var data = repo.GetByDateTitle(date, title);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<NewsDTO>>(data);
            return ret;
        }
    }
}
