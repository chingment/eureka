using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBack.Areas.Manager.Models.Mod
{
    public class BannerSearchCondition:SearchCondition
    {
        public string Code { get; set; }

        public string Title { get; set; }
    }
}