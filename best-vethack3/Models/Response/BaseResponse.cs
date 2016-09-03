using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace best_vethack3.Models.Response
{
    public abstract class BaseResponse
    {
        public bool IsSuccessful { get; set; }
    }
}