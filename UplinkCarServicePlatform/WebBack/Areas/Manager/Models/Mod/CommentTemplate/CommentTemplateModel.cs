using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBack.Areas.Manager.Models.Mod
{
    public class CommentTemplateModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Usage { get; set; }

        public string Content { get; set; }

        public bool IsDefault { get; set; }
    }
}