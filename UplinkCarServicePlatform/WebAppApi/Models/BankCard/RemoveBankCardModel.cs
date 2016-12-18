using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppApi.Models.BankCard
{
    public class RemoveBankCardModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int MerchantId { get; set; }
    }
}