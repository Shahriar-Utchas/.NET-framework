using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PostComment.Auth
{
    public class Logged: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            if (token == null) {

                actionContext.Response = 
                    actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Message = "Token is missing" });
            }
            else if (!AuthService.IsValidateToken(token.ToString())){
                actionContext.Response = 
                    actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Message = "Supplied Token is not invalid or expired!" });

            }
            base.OnAuthorization(actionContext);
        }
    }
}