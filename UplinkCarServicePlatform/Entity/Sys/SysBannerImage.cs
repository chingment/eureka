using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lumos.Entity
{
    [Table("SysBannerImage")]
    public class SysBannerImage
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int BannerId { get; set; }

        public Enumeration.BannerType Type { get; set; }

        public string Title  { get; set; }

        public bool IsLink { get; set; }

        public string Content { get; set; }

        public string ImgUrl { get;  set; }

        public int ReadCount { get; set; }

        public int Priority{  get;  set;   }

        public int Creator { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDelete { get; set; }

    }
}
