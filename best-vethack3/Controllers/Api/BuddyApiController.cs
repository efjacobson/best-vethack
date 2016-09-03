using best_vethack3.Models.Domain;
using best_vethack3.Models.Response;
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
    [RoutePrefix("api/buddy")]
    public class BuddyApiController : ApiController
    {
        [Route]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                List<Buddy> allBuddies = new List<Buddy>();
                allBuddies = await BuddyService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, allBuddies);
            }
            catch (Exception exception)
            {
                ErrorResponse errorResponse = new ErrorResponse(exception.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errorResponse);
            }
        }
    }
}
