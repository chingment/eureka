using Lumos.BLL;
using Lumos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppApi.Models.Account;

namespace WebAppApi.Controllers
{
    public class AccountController : BaseApiController
    {

        [HttpPost]
        public APIResponse Login(LoginModel model)
        {
            LoginManager<SysClientUser> loginManagr = new LoginManager<SysClientUser>();
            var loginResult = loginManagr.SignIn(model.UserName, model.Password, "", Enumeration.LoginType.AndroidApp);

            if (loginResult.ResultType != Enumeration.LoginResult.Success)
            {
                return ResponseResult(ResultType.Failure, ResultCode.FailureSign, "登录失败，用户名或密码错误");
            }

            LoginResultModel resultModel = new LoginResultModel(loginResult.User, model.FuselageNumber);

            return ResponseResult(ResultType.Success, ResultCode.Success, "登录成功", resultModel); 
        }

        public APIResponse GetDetails()
        {
            APIResult result = new APIResult() { Result = ResultType.Exception, Code = ResultCode.Failure, Message = "NULL" };
            return new APIResponse(result);
        }

        public APIResponse Edit()
        {
            APIResult result = new APIResult() { Result = ResultType.Exception, Code = ResultCode.Failure, Message = "NULL" };
            return new APIResponse(result);
        }

        [HttpPost]
        public APIResponse ChangePassword()
        {
            APIResult result = new APIResult() { Result = ResultType.Exception, Code = ResultCode.Failure, Message = "NULL" };
            return new APIResponse(result);
        }

        [HttpGet]
        public APIResponse GetChildAccountList()
        {
            APIResult result = new APIResult() { Result = ResultType.Exception, Code = ResultCode.Failure, Message = "NULL" };
            return new APIResponse(result);
        }

        [HttpPost]
        public APIResponse AddChildAccount()
        {
            APIResult result = new APIResult() { Result = ResultType.Exception, Code = ResultCode.Failure, Message = "NULL" };
            return new APIResponse(result);
        }

        public APIResponse EditChildAccount()
        {
            APIResult result = new APIResult() { Result = ResultType.Exception, Code = ResultCode.Failure, Message = "NULL" };
            return new APIResponse(result);
        }

        [HttpPost]
        public APIResponse GetChildAccountDetails()
        {
            APIResult result = new APIResult() { Result = ResultType.Exception, Code = ResultCode.Failure, Message = "NULL" };
            return new APIResponse(result);
        }
    }
}