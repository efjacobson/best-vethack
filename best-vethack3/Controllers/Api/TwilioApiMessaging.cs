using best_vethack3.Models;
using best_vethack3.Models.Response;
using best_vethack3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Twilio;

namespace best_vethack3.Controllers.Api
{
    [RoutePrefix("Api/messaging")]
    public class TwilioApiController : ApiController
    {

        [Route(), HttpPost]
        public HttpResponseMessage SendMessage(TwilioMessaging model)
        {
            try
            {

                model.MessageBody = model.MessageBody + Environment.NewLine + Environment.NewLine + model.MyPhone + Environment.NewLine + Environment.NewLine + model.Signature;
                TwilioService.SendMessage(model.PhoneNumberTo, model.MessageBody);
                SuccessResponse response = new SuccessResponse();
                return Request.CreateResponse(response);
            }
            catch (Exception ex)
            {
                var response = new ErrorResponse(ex.Message);
                return Request.CreateResponse(response);
            }

        }
    }
}