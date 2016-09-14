using best_vethack3.Models.Request;
using best_vethack3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace best_vethack3.Controllers.Api
{
    [RoutePrefix("api/user")]
    public class UserApiController : ApiController
    {
        private readonly UserService userService = new UserService();

        [Route]
        [HttpPost]
        public HttpResponseMessage Login()
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.EmailAddress = "test@test.com";
            loginRequest.Password = "Password1!";
            loginRequest.IsPersistent = false;

            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Task<bool> whatever;

            if (loginRequest != null)
            {
                whatever = userService.SignIn(loginRequest);
            }

            //if (!await userService.SignIn(loginRequest))
            //{
            //    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            //}

            return Request.CreateResponse(HttpStatusCode.Accepted, ModelState);
        }
    }
}
