using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBack.Areas.Manager
{
    public static class ManagerStaticScriptsResource
    {
        public static IHtmlString Render(string path)
        {

            string strUrl = System.Configuration.ConfigurationManager.AppSettings["custom:StaticResourceServerUrl"];
            if (strUrl == null)
            {
                strUrl = "/Areas/Manager/Scripts/" + path;
            }
            else
            {
               
            }

            return new MvcHtmlString("<script src=\"" + strUrl + "\" type=\"text/javascript\"></script>");
        }
    }

    public static class ManagerStaticStylesResource
    {
        public static IHtmlString Render(string path)
        {
            string strUrl = System.Configuration.ConfigurationManager.AppSettings["custom:StaticResourceServerUrl"];
            if (strUrl == null)
            {
                strUrl = "/Areas/Manager/Content/" + path;
            }
            else
            {
               
            }

            return new MvcHtmlString("<link href=\"" + strUrl + "\" rel=\"stylesheet\"/>");
        }
    }

}