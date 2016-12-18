using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumos.Entity
{
    [Table("BankCard")]
    public class BankCard
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int MerchantId { get; set; }

        public int BankId { get; set; }

        public string BankCode { get; set; }

        public string BankName { get; set; }

        public string BankAccountName { get; set; }

        public string BankAccountNo { get; set; }

        public string BankAccountPhone { get; set; }

        public bool IsDelete { get; set; }
    }
}
