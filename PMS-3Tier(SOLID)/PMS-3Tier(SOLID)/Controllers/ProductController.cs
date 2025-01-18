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
    public class ProductController : ApiController
    {
        [HttpPost]
        [Route("api/product/add")]
        public HttpResponseMessage AddCategory(ProductCategoryDTO p)
        {
            var data = ProductService.Add(p);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/product/update")]
        public HttpResponseMessage UpdateCategory(ProductDTO p)
        {
            var data = ProductService.UpdateProduct(p);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/product/get")]
        public HttpResponseMessage GetCategories()
        {
            var data = ProductService.GetProducts();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/product/get/{id}")]
        public HttpResponseMessage GetCategory(int id)
        {
            var data = ProductService.GetProduct(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/product/delete/{id}")]
        public HttpResponseMessage DeleteCategory(int id)
        {
            var data = ProductService.DeleteProduct(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/product/getbycategory/{id}")]
        public HttpResponseMessage GetProductsByCategory(int id)
        {
            var data = ProductService.GetProductsByCategory(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
