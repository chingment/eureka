using System.Web;
using System.Web.Mvc;
using WebBack.Areas.Manager;
using WebBack.Areas.Manager.Controllers;

namespace WebBack
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //监控引用
            filters.Add(new ManagerStatisticsTrackerAttribute());
        }
    }
}
