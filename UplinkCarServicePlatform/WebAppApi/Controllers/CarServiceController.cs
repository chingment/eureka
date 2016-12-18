using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppApi.Controllers
{
    public class CarServiceController : BaseApiController
    {
        public APIResponse GetInsurePlan()
        {
            APIResult result = new APIResult() { Result = ResultType.Exception, Code = ResultCode.Failure, Message = "NULL" };

            return new APIResponse(result);
        }

        public APIResponse GetInsureComany()
        {
            APIResult result = new APIResult() { Result = ResultType.Exception, Code = ResultCode.Failure, Message = "NULL" };

            return new APIResponse(result);
        }

        public APIResponse SubmitPolicy()
        {
            APIResult result = new APIResult() { Result = ResultType.Exception, Code = ResultCode.Failure, Message = "NULL" };

            return new APIResponse(result);
        }



        //public APIResponse GetInsureComany()
        //{
        //    APIResult result = new APIResult() { Result = ResultType.Exception, Code = ResultCode.SignError, Message = "NULL" };

        //    return new APIResponse(result);
        //}
    }
}