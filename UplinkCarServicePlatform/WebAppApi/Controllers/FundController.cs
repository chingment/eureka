using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppApi.Models.Banner;
using Lumos.Entity;

namespace WebAppApi.Controllers
{
    public class FundController : BaseApiController
    {
        [HttpGet]
        public APIResponse GetDetails(int userId,int merchantId)
        {
            APIResult result = new APIResult() { Result = ResultType.Exception, Code = ResultCode.Failure, Message = "NULL" };

            return new APIResponse(result);
        }

        [HttpGet]
        public APIResponse GetTransaction(int userId, int merchantId)
        {
            APIResult result = new APIResult() { Result = ResultType.Exception, Code = ResultCode.Failure, Message = "NULL" };

            return new APIResponse(result);
        }

        [HttpPost]
        public APIResponse WithdrawApply(int userId, int merchantId)
        {
            APIResult result = new APIResult() { Result = ResultType.Exception, Code = ResultCode.Failure, Message = "NULL" };

            return new APIResponse(result);
        }


    }
}