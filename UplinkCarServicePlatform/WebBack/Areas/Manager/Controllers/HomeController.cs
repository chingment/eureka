using Lumos.Common;
using Lumos.DAL.AuthorizeRelay;
using Lumos.Entity;
using log4net;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using WebBack.Areas.Manager.Models.Home;
using Lumos.Mvc;
using System;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using Lumos.BLL;

namespace WebBack.Areas.Manager.Controllers
{

    public class HomeController : ManagerController
    {

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Main()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {

            Session["ManagerLoginVerifyCode"] = null;
            if (Request.IsAuthenticated)
            {
                if (Request.QueryString["out"] == null)
                {
                    return Redirect(ManagerConfig.GetHomePage());
                }
            }

            return View();
        }


        public ViewResult ChangePassword()
        {
            return View();
        }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [CheckVerifyCode("ManagerLoginVerifyCode")]
        public JsonResult Login(LoginModel model)
        {
            GoToViewModel gotoViewModel = new GoToViewModel();
            gotoViewModel.Url = ManagerConfig.GetLoginPage();


            LoginManager<SysStaffUser> loginManager = new LoginManager<SysStaffUser>();

            var result = loginManager.SignIn(model.UserName, model.Password, CommonUtils.GetIP(),Enumeration.LoginType.Website);


            if (result.ResultType == Enumeration.LoginResult.Failure)
            {

                if (result.ResultTip == Enumeration.LoginResultTip.UserNotExist || result.ResultTip == Enumeration.LoginResultTip.UserPasswordIncorrect)
                {
                    return Json(ResultType.Failure, gotoViewModel, ManagerOperateTipUtils.LOGIN_USERNAMEORPASSWORDINCORRECT);
                }

                if (result.ResultTip == Enumeration.LoginResultTip.UserDisabled)
                {
                    return Json(ResultType.Failure, gotoViewModel, ManagerOperateTipUtils.LOGIN_ACCOUNT_DISABLED);
                }

                if (result.ResultTip == Enumeration.LoginResultTip.UserDeleted)
                {
                    return Json(ResultType.Failure, gotoViewModel, ManagerOperateTipUtils.LOGIN_ACCOUNT_DELETE);
                }
            }

            gotoViewModel.Url = ManagerConfig.GetHomePage();
            return Json(ResultType.Success, gotoViewModel, ManagerOperateTipUtils.LOGIN_SUCCESS);

        }

        /// <summary>
        /// 退出方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            ILog log = LogManager.GetLogger(CommonSetting.LoggerLoginWeb);
            log.Info(FormatUtils.LoginOffWeb(User.Identity.GetUserId<int>(), User.Identity.GetUserName()));
            var identity = new AspNetIdentiyAuthorizeRelay<SysUser>();
            identity.SignOut();
            return Redirect(ManagerConfig.GetLoginPage());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ChangePassword(ChangePasswordModel model)
        {
            string oldPassword = model.OldPassword;
            string newPassword = model.NewPassword;
            var authorizeRelay = new AspNetIdentiyAuthorizeRelay<SysUser>();
            bool result = authorizeRelay.ChangePassword(User.Identity.GetUserId<int>(), oldPassword, newPassword);

            if (!result)
            {
                return Json(ResultType.Failure, ManagerOperateTipUtils.CHANGEPASSWORD_OLDPASSWORDINCORRECT);
            }



            if (Request.IsAuthenticated)
            {
                authorizeRelay.SignOut();
            }


            return Json(ResultType.Success, "点击<a href=\"" + ManagerConfig.GetLoginPage() + "\">登录</a>");

        }

    }
}