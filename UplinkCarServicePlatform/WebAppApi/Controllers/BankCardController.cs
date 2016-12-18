using Lumos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppApi.Models.BankCard;

namespace WebAppApi.Controllers
{
    public class BankCardController : BaseApiController
    {
        [HttpGet]
        public APIResponse GetList(int userId, int merchantId)
        {
            var bankCards = CurrentDb.BankCard.Where(m => m.UserId == userId && m.MerchantId == merchantId && m.IsDelete == false).ToList();

            List<BankCardModel> models = new List<BankCardModel>();

            foreach (var m in bankCards)
            {
                BankCardModel bankCardModel = new BankCardModel();
                bankCardModel.Id = m.Id;
                bankCardModel.BankId = m.Id;
                bankCardModel.BankCode = m.BankCode;
                bankCardModel.BankName = m.BankName;
                bankCardModel.BankAccountNo = m.BankAccountNo;
                models.Add(bankCardModel);
            }

            APIResult result = new APIResult() { Result = ResultType.Success, Code = ResultCode.Success, Message = "成功", Data = models };
            return new APIResponse(result);
        }

        [HttpPost]
        public APIResponse Bind(BindBankCardModel model)
        {

            var bank = CurrentDb.Bank.Where(m => m.Id == model.BankId).FirstOrDefault();

            BankCard bankCard = new BankCard();
            bankCard.UserId = model.UserId;
            bankCard.MerchantId = model.MerchantId;
            bankCard.BankId = bank.Id;
            bankCard.BankCode = bank.Code;
            bankCard.BankName = bank.Name;
            bankCard.BankAccountName = model.BankAccountName;
            bankCard.BankAccountNo = model.BankAccountNo;
            bankCard.BankAccountPhone = model.BankAccountPhone;
            CurrentDb.BankCard.Add(bankCard);
            CurrentDb.SaveChanges();


            APIResult result = new APIResult() { Result = ResultType.Success, Code = ResultCode.Success, Message = "绑定成功" };
            return new APIResponse(result);
        }

        [HttpPost]
        public APIResponse Remove(RemoveBankCardModel model)
        {
            var bankCard = CurrentDb.BankCard.Where(m => m.Id == model.Id && m.MerchantId == model.MerchantId).FirstOrDefault();
            bankCard.IsDelete = true;
            CurrentDb.SaveChanges();

            APIResult result = new APIResult() { Result = ResultType.Success, Code = ResultCode.Success, Message = "解绑成功" };

            return new APIResponse(result);
        }
    }
}