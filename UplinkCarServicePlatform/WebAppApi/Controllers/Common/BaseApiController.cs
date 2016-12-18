using Lumos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebAppApi
{

    public  class BaseApiController : ApiController
    {
        private APIResult _result = new APIResult();
        private LumosDbContext _currentDb;

        public APIResult Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        public LumosDbContext CurrentDb
        {
            get
            {
                return _currentDb;
            }
        }


        public BaseApiController()
        {
            _currentDb = new LumosDbContext();
            _result = new APIResult { Result = ResultType.Unknown, Code = ResultCode.Unknown, Message = "未知" };
        }

        public APIResponse ResponseResult(APIResult result)
        {
            return new APIResponse(result);
        }

        public APIResponse ResponseResult(ResultType resultType, ResultCode resultCode, string message=null, object data = null)
        {
            _result.Result = resultType;
            _result.Code = resultCode;
            _result.Message = message;
            _result.Data = data;
            return new APIResponse(_result);
        }
    }
}