using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace best_vethack3.Controllers.Api
{
    [RoutePrefix("api/buddy")]
    public class BuddyApiController : ApiController
    {
        [Route]
        [HttpGet]
        public int GetAll()
        {
            return 1;
        }
    }
}
