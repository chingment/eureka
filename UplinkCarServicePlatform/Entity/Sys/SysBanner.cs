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
    [Table("SysBanner")]
    public class SysBanner
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Enumeration.BannerType Type { get; set; }

        public string Title{ get; set;}

        public string Description { get; set; }

        public int Creator { get; set; }

        public DateTime CreateTime { get; set; }

        public int? Mender { get; set; }

        public DateTime? LastUpdateTime { get; set; }

    }
}
