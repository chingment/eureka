using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBack.Areas.Manager.Models
{
    public class SearchCondition
    {
        public string Name { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}