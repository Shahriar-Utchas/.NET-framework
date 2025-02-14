using BLL.Services;
using PostComment.Auth;
using PostComment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PostComment.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginModel log)
        {
            try
            {
                var data = AuthService.Authenticate(log.Uname, log.Password);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Invalid username or password" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [Logged]
        [HttpGet]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
                var token = Request.Headers.Authorization.ToString();
            try
            {
                var res = AuthService.Logout(token);
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Logged out successfully" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }
    }

}
