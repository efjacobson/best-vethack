using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace best_vethack3.Models.Response
{
    public class SuccessResponse : BaseResponse
    {
        public SuccessResponse()
        {

            this.IsSuccessFul = true;
        }
    }
  
}