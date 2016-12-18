using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAppApi.Controllers;

namespace WebAppApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            HttpApplication ap = sender as HttpApplication;
            System.Exception ex = ap.Server.GetLastError();

            var httpStatusCode = (ex is HttpException) ? (ex as HttpException).GetHttpCode() : 500; //这里仅仅区分两种错误 
            switch (httpStatusCode)
            {
                case 404:
                    break;
                default:
                    log.Error("应用程序捕捉到异常", ex);
                    APIResult result = new APIResult(ResultType.Exception, ResultCode.Exception, "程序内容错误");
                    ap.Context.Response.Write("fsdffdsf");
                    ap.Context.Response.End();
                    break;
            }
        }
    }
}
