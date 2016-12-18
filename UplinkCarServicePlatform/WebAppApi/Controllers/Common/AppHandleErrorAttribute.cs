using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WebAppApi
{
    public class AppHandleErrorAttribute : HandleErrorAttribute
    {
        /// <summary>

        /// 异常

        /// </summary>

        /// <param name="filterContext"></param>

        public override void OnException(ExceptionContext filterContext)

        {
            ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            //使用log4net或其他记录错误消息

            Exception Error = filterContext.Exception;

            string Message = Error.Message;//错误信息

            string Url = HttpContext.Current.Request.RawUrl;//错误发生地址

            log.Error(Error);


            filterContext.ExceptionHandled = true;

            filterContext.Result = new RedirectResult("/SiteStatus/HtmlError500/?q=" + Message);//跳转至错误提示页面

        }
    }
}