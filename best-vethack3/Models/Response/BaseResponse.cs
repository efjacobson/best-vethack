using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace best_vethack3.Models.Response
{
    public abstract class BaseResponse
    {
        public bool IsSuccessFul { get; set; }

        public string TransactionId { get; set; }

        public BaseResponse()
        {

            this.TransactionId = Guid.NewGuid().ToString();
        }
    }
}