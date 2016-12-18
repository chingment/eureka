using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppApi.Models.Banner
{
    public class BannerImageModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ReadCount { get; set; }

        public string Content { get; set; }

        public bool IsLink { get; set; }

        public string ImgUrl { get; set; }

    }
}