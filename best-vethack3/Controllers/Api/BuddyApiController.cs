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

        [Route("create"), HttpPost]
        public async Task<HttpResponseMessage> Create(Buddy model)
        {
            try
            {
                Buddy buddy = new Buddy();
                buddy.FirstName = model.FirstName;
                buddy.LastName = model.LastName;
                buddy.PhoneNumber = model.PhoneNumber;
                buddy.Age = model.Age;
                buddy.IsActive = model.IsActive;
                buddy.Branch = model.Branch;
                buddy.Rank = model.Rank;
                buddy.YearsServed = model.YearsServed;
                buddy.Location = model.Location;
                buddy.CurrentOccupation = model.CurrentOccupation;
                buddy.TagLine = model.TagLine;
                buddy.Bio = model.Bio;
                await BuddyService.Create(buddy);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exception)
            {
                ErrorResponse errorResponse = new ErrorResponse(exception.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errorResponse);
            }
        }

        [Route("test")]
        [HttpGet]
        public HttpResponseMessage Test()
        {
            return Request.CreateResponse(HttpStatusCode.OK, 1);
        }
    }
}
