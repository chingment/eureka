using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebAppApi.Controllers
{
    public class WithdrawController: BaseApiController
    {
        [HttpPost]
        public APIResponse Apply()
        {
            APIResult result = new APIResult() { Result = ResultType.Exception, Code = ResultCode.Failure, Message = "NULL" };
            return new APIResponse(result);
        }
    }
}