using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBack.Areas.Manager.Models.Sys.StaffUser
{
    public class StaffUserSearchCondition : SearchCondition
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
    }
}