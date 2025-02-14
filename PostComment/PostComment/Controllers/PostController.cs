using BLL.Services;
using PostComment.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PostComment.Controllers
{
    public class PostController : ApiController
    {
        [HttpGet]
        [Route("api/posts")]
        public HttpResponseMessage getPosts()
        {
            try
            {
                var data = PostService.GetPosts();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpGet]
        [Route("api/post/{id}")]
        public HttpResponseMessage getPost(int id)
        {
            try
            {
            var data = PostService.GetPost(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {Message = ex.Message});
            }

        }
        [HttpGet]
        [Route("api/posts/comments")]
        public HttpResponseMessage getPostWithComments()
        {
            try
            {
                var data = PostService.GetPostWithComments();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/post/comments/{id}")]
        public HttpResponseMessage getPostWithComments(int id)
        {
            try
            {
                var data = PostService.GetPostWithComments(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
