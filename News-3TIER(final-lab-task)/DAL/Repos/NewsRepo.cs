using DAL.EF.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class NewsRepo : Repo
    {
        public List<News> GetAll()
        {
            return db.News.ToList();
        }
        public News GetByID(int id)
        {
            return db.News.Find(id);
        }
        public void Create(News news)
        {

            db.News.Add(news);
            db.SaveChanges();
        }
        public string Update(News news)
        {
            var data = db.News.Find(news.ID);
            if (data == null)
            {
                return "not found";
            }
            else
            {
                data.Title = news.Title;
                data.Category = news.Category;
                data.Date = news.Date;
                db.SaveChanges();
                return "Updated";
            }
        }
        public void Delete(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
        }
        public List<News> GetByCategory(string category)
        {
            var data = db.News.Where(x => x.Category == category).ToList();
            return data;
        }
        public List<News> GetByDate(DateTime date)
        {
            var data = db.News.Where(x => x.Date == date).ToList();
            return data;
        }
        public List<News> GetByTitle(string title)
        {
            var data = db.News.Where(x => x.Title == title).ToList();
            return data;
        }
        public List<News> GetByDateCategory(DateTime date, string category)
        {
            var data = db.News.Where(x => x.Date == date && x.Category == category).ToList();
            return data;
        }
        public List<News> GetByDateTitle(DateTime date, string title)
        {
            var data = db.News.Where(x => x.Date == date && x.Title == title).ToList();
            return data;
        }

    }
}
