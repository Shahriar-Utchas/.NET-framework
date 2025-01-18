using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PMS_3Tier_SOLID_.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("api/category/all")]
        public HttpResponseMessage GetCategories()
        {
            var data = CategoryService.GetCategories();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/category/{id}")]
        public HttpResponseMessage GetCategory(int id)
        {
            var data = CategoryService.GetCategory(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/category/add")]
        public HttpResponseMessage AddCategory(CategoryDTO category)
        {
            var data = CategoryService.AddCategory(category);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/category/update")]
        public HttpResponseMessage UpdateCategory(CategoryDTO category)
        {
            var data = CategoryService.UpdateCategory(category);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/category/delete/{id}")]
        public HttpResponseMessage DeleteCategory(int id)
        {
            var data = CategoryService.DeleteCategory(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
