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

        [Route("{id:int}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetById(int id)
        {
            try
            {
                Buddy buddy = await BuddyService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, buddy);
            }
            catch (Exception exception)
            {
                ErrorResponse errorResponse = new ErrorResponse(exception.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errorResponse);
            }
        }

        [Route]
        [HttpPut]
        public async Task<HttpResponseMessage> Create()
        {
            try
            {
                Buddy buddy = new Buddy();
                buddy.FirstName = "test";
                buddy.LastName = "test";
                buddy.Age = 1;
                buddy.IsActive = 1;
                buddy.Branch = "test";
                buddy.Rank = "test";
                buddy.YearsServed = 1;
                buddy.Location = "test";
                buddy.CurrentOccupation = "test";
                buddy.TagLine = "test";
                buddy.Bio = "test";
                int id = await BuddyService.Create(buddy);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception exception)
            {
                ErrorResponse errorResponse = new ErrorResponse(exception.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errorResponse);
            }
        }
    }
}
