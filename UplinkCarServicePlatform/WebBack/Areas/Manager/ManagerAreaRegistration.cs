using System.Web.Mvc;

namespace WebBack.Areas.Manager
{
    public class ManagerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Manager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               name: "Manager_sys",
               url: "Manager/Sys/{controller}/{action}/{type}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, type = UrlParameter.Optional },
               namespaces: new string[] { "WebBack.Areas.Manager.Controllers" }
            );


            context.MapRoute(
             name: "Manager_mod",
             url: "Manager/Mod/{controller}/{action}/{type}/{id}",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, type = UrlParameter.Optional },
             namespaces: new string[] { "WebBack.Areas.Manager.Controllers" }
          );

            context.MapRoute(
         name: "Manager_biz",
         url: "Manager/Biz/{controller}/{action}/{type}/{id}",
         defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, type = UrlParameter.Optional },
         namespaces: new string[] { "WebBack.Areas.Manager.Controllers" }
      );

            context.MapRoute(
name: "Manager_default",
url: "Manager/{controller}/{action}/{type}/{id}",
defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, type = UrlParameter.Optional },
namespaces: new string[] { "WebBack.Areas.Manager.Controllers" }
);

        }
    }
}