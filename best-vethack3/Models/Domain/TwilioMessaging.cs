using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace best_vethack3.Models
{
    public class TwilioMessaging
    {
        [Required, MinLength(5), MaxLength(15)]
        public string PhoneNumberTo { get; set; }

        [Required, MinLength(2)]
        public string MessageBody { get; set; }

        public string Signature { get; set; }

        public string MyPhone { get; set; }
    }
}
