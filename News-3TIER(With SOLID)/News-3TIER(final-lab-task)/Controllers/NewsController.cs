using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace News_3TIER_final_lab_task_.Controllers
{
    public class NewsController : ApiController
    {
        public NewsService service = new NewsService();
        [HttpGet]
        [Route("api/news")]
        public HttpResponseMessage GetAll()
        {
            var data = service.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/news/{id}")]
        public HttpResponseMessage GetByID(int id)
        {
            var data = service.GetByID(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/news/addNews")]
        public HttpResponseMessage Create(NewsDTO news)
        {
            service.Create(news);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPost]
        [Route("api/news/updateNews/{id}")]
        public HttpResponseMessage Update(NewsDTO news, int id)
        {
            news.ID = id;
            var data = service.Update(news);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/news/deleteNews/{id}")]

        public HttpResponseMessage Delete(int id)
        {
            service.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpGet]
        [Route("api/news/getByCategory/{category}")]
        public HttpResponseMessage GetByCategory(string category)
        {
            var data = service.GetByCategory(category);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/news/getByDate/{date}")]
        public HttpResponseMessage GetByDate(DateTime date)
        {
            var data = service.GetByDate(date);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/news/getByTitle/{title}")]
        public HttpResponseMessage GetByTitle(string title)
        {
            var data = service.GetByTitle(title);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/news/getByDatecategory/{date}/{category}")]
        public HttpResponseMessage GetByDateCategory(DateTime date, string category)
        {
            var data = service.GetByDateCategory(date, category);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/news/getByDateTitle/{date}/{title}")]
        public HttpResponseMessage GetByDateTitle(DateTime date, string title)
        {
            var data = service.GetByDateTitle(date, title);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

    }
}
