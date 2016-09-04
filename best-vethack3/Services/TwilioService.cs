using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;

namespace best_vethack3.Service
{
    public class TwilioService
    {
        public static string SendMessage(string phoneNumberTo, string messageBody)
        {
            var accountSid = "AC975eb1a653a4fc23e5d7c59373414b00";
            var accountToken = "f242cda9f67746da4ad0409e70a87edb";

            var twilio = new TwilioRestClient(accountSid, accountToken);
            var message = twilio.SendMessage(
                "+13104395418"
                , phoneNumberTo
                , messageBody
                );

            return message.Status;
        }
    }
}