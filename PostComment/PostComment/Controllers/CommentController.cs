using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PostComment.Controllers
{
    public class CommentController : ApiController
    {
        [HttpGet]
        [Route("api/comments")]
        public HttpResponseMessage getComments()
        {
            try
            {
                var data = CommentService.GetComments();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/comment/{id}")]
        public HttpResponseMessage getComment(int id)
        {
            try
            {
                var data = CommentService.GetComment(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
