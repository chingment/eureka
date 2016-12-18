using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumos.Entity
{
    [Table("ExtendedApp")]
    public class ExtendedApp
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Enumeration.ExtendedAppType Type { get; set; }

        public string Name { get; set; }

        public string LinkUrl { get; set; }

        public string ImgUrl { get; set; }

        public string AccessCount { get; set; }

        public bool IsDisplay { get; set; }
    }
}
