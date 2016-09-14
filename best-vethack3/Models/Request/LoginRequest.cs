using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace best_vethack3.Models.Request
{
    public class LoginRequest
    {
        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        [Required, MaxLength(200)]
        public string Password { get; set; }

        public bool IsPersistent { get; set; }
    }
}