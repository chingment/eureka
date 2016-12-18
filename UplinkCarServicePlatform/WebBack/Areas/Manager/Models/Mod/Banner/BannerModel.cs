using Lumos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBack.Areas.Manager.Models.Mod
{
    public class BannerModel
    {
        public BannerModel()
        {
            this.Images = new List<SysBannerImage>();
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Link { get; set; }

        public List<SysBannerImage> Images { get; set; }

    }
}