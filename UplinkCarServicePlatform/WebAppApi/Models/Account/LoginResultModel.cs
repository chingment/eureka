using Lumos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppApi.Models.Account
{
    public class LoginResultModel : BaseViewModel
    {

        public LoginResultModel(SysClientUser sysClientUser, string fuselageNumber)
        {
            this.UserId = sysClientUser.Id;
            this.UserName = sysClientUser.UserName;
            this.FullName = sysClientUser.FullName;
            this.AccountType = sysClientUser.ClientAccountType;
            this.MerchantId = sysClientUser.MerchantId;

            var posMachine = CurrentDb.PosMachine.Where(m => m.FuselageNumber == fuselageNumber && m.MerchantId == sysClientUser.MerchantId).FirstOrDefault();
            if (posMachine != null)
            {
                this.PosMachineStatus = posMachine.Status;
            }

        }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public Enumeration.ClientAccountType AccountType { get; set; }

        public Enumeration.PosMachineStatus PosMachineStatus { get; set; }

        public int MerchantId { get; set; }

    }
}