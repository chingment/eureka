using Lumos.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebAppApi.Models.Account;
using WebAppApi.Models.BankCard;

namespace WebAppApi.Controllers
{
    public class HomeController : Controller
    {
        private string key = "DSDADS3423424DFF";
        private string secret = "6ZB97cdVz211O08EKZ6yriAYrHXFBowC";
        private long timespan = (long)(DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;

        public static string GetQueryString(Dictionary<string, string> parames)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parames);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder("");  //签名字符串
            StringBuilder queryStr = new StringBuilder(""); //url参数
            if (parames == null || parames.Count == 0)
                return "";

            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key))
                {
                    queryStr.Append("&").Append(key).Append("=").Append(value);
                }
            }

            string s = queryStr.ToString().Substring(1, queryStr.Length - 1);

            return s;
        }


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";


            Dictionary<string, string> model = new Dictionary<string, string>();

            int userId = 1;
            int merchantId = 1;
            model.Add("获取全部服务", GetExtendedAppList(ExtendedAppType.All));

            model.Add("获取车务服务", GetExtendedAppList(ExtendedAppType.MainHomeCarService));

            model.Add("获取推荐服务", GetExtendedAppList(ExtendedAppType.MainHomeRecommend));

            model.Add("获取Banner", GetBannerList(Enumeration.BannerType.MainHomeTop));

            model.Add("获取Banner详细", GetBannerDetails("4"));

            model.Add("获取银行列表", GetBankList());

            model.Add("获取银行卡列表", GetBankCardList(userId, merchantId));


            model.Add("绑定银行卡", BindBankCard(userId, merchantId));

            model.Add("解绑银行卡", RemoveBankCard(1,userId, merchantId));
            //string body_data = "";

            //HttpUtil http = new HttpUtil();
            //int a = int.Parse("Dasd");

            //DateTime now = DateTime.Now;
            //var timesSpan = (now - new DateTime(1970, 1, 1, 0, 0, 0));

            //Dictionary<string, string> parames = new Dictionary<string, string>();
            //parames.Add("id", "1110");



            //string signStr = Signature.Compute("DSDADS3423424DFF", "6ZB97cdVz211O08EKZ6yriAYrHXFBowC", (long)timesSpan.TotalSeconds, Signature.GetQueryData(parames));

            //Dictionary<string, string> headers = new Dictionary<string, string>();
            //headers.Add("key", "DSDADS3423424DFF");
            //headers.Add("timestamp", ((long)timesSpan.TotalSeconds).ToString());
            //headers.Add("sign", signStr);


            //// string respon_data1 = http.HttpGet("http://localhost:1664/api/Banner/GetDetails?id=1110", headers);
            ////string respon_data2 = http.HttpGet("http://localhost:1664/api/Banner/GetList", headers);


            ////LoginModel model = new LoginModel();
            ////model.UserName = "ching";
            ////model.Password = "123456";
            ////string a = JsonConvert.SerializeObject(model);
            ////string respon_data3 = http.HttpPostJson("http://localhost:1664/api/Account/Login", Newtonsoft.Json.JsonConvert.SerializeObject(model), headers);


            //LoginModel model1 = new LoginModel();
            //model1.UserName = "chkhhkjhhhing01";
            //model1.Password = "12345jggjgjhjghggjg6";
            //model1.FuselageNumber = "das";
            //string a1 = JsonConvert.SerializeObject(model1);

            //string signStr1 = Signature.Compute("DSDADS3423424DFF", "6ZB97cdVz211O08EKZ6yriAYrHXFBowC", timespan, a1);

            //Dictionary<string, string> headers1 = new Dictionary<string, string>();
            //headers1.Add("key", "DSDADS3423424DFF");
            //headers1.Add("timestamp", ((long)timesSpan.TotalSeconds).ToString());
            //headers1.Add("sign", signStr1);

            //// string a1 = "a1=das&a2=323";

            //string respon_data4 = http.HttpPostJson("http://localhost:1664/api/Account/Login", a1, headers1);

            //// string a5 = "a1=das&a2=323";
            ////  string respon_data5 = http.HttpPostJson("http://localhost:1664/api/Account/Login", a1, headers);


            return View(model);
        }

        public string GetBannerList(Enumeration.BannerType type)
        {
            Dictionary<string, string> parames = new Dictionary<string, string>();
            parames.Add("type", ((int)type).ToString());

            string signStr = Signature.Compute(key, secret, timespan, Signature.GetQueryData(parames));

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("key", key);
            headers.Add("timestamp", timespan.ToString());
            headers.Add("sign", signStr);
            HttpUtil http = new HttpUtil();
            string result = http.HttpGet("http://localhost:1664/api/Banner/GetList?type=" + ((int)type).ToString(), headers);

            return result;

        }

        public string GetBannerDetails(string id)
        {
            Dictionary<string, string> parames = new Dictionary<string, string>();
            parames.Add("id", id);

            string signStr = Signature.Compute(key, secret, timespan, Signature.GetQueryData(parames));

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("key", key);
            headers.Add("timestamp", timespan.ToString());
            headers.Add("sign", signStr);
            HttpUtil http = new HttpUtil();
            string result = http.HttpGet("http://localhost:1664/api/Banner/GetDetails?id=" + id, headers);

            return result;

        }

        public string GetExtendedAppList(ExtendedAppType type)
        {
            Dictionary<string, string> parames = new Dictionary<string, string>();
            parames.Add("type", ((int)type).ToString());
            parames.Add("userId", ((int)type).ToString());
            parames.Add("fuselageNumber", "sfsdffsffsf");
            string signStr = Signature.Compute(key, secret, timespan, Signature.GetQueryData(parames));

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("key", key);
            headers.Add("timestamp", timespan.ToString());
            headers.Add("sign", signStr);
            HttpUtil http = new HttpUtil();
            string result = http.HttpGet("http://localhost:1664/api/ExtendedApp/GetList?type=" + ((int)type).ToString() + "&userId=" + ((int)type).ToString() + "&fuselageNumber=sfsdffsffsf", headers);

            return result;

        }

        public string GetBankList()
        {

            string signStr = Signature.Compute(key, secret, timespan, null);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("key", key);
            headers.Add("timestamp", timespan.ToString());
            headers.Add("sign", signStr);
            HttpUtil http = new HttpUtil();
            string result = http.HttpGet("http://localhost:1664/api/Bank/GetList", headers);

            return result;

        }

        public string GetBankCardList(int userId, int merchantId)
        {
            Dictionary<string, string> parames = new Dictionary<string, string>();
            parames.Add("userId", userId.ToString());
            parames.Add("merchantId", merchantId.ToString());
            string signStr = Signature.Compute(key, secret, timespan, Signature.GetQueryData(parames));

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("key", key);
            headers.Add("timestamp", timespan.ToString());
            headers.Add("sign", signStr);
            HttpUtil http = new HttpUtil();
            string result = http.HttpGet("http://localhost:1664/api/BankCard/GetList?userId=" + userId.ToString() + "&merchantId=" + merchantId, headers);

            return result;

        }

        public string BindBankCard(int userId, int merchantId)
        {

            BindBankCardModel model = new BindBankCardModel();
            model.UserId = userId;
            model.MerchantId = merchantId;
            model.BankId = 1;
            model.BankAccountPhone = "15989287032";
            model.BankAccountName = "邱庆文";
            model.BankAccountNo = "545553232321";
            string a1 = JsonConvert.SerializeObject(model);

            string signStr = Signature.Compute(key, secret, timespan, a1);


            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("key", key);
            headers.Add("timestamp", timespan.ToString());
            headers.Add("sign", signStr);
            HttpUtil http = new HttpUtil();
            string result = http.HttpPostJson("http://localhost:1664/api/BankCard/Bind", a1, headers);

            return result;

        }

        public string RemoveBankCard(int id,int userId, int merchantId)
        {

            RemoveBankCardModel model = new RemoveBankCardModel();
            model.UserId = userId;
            model.MerchantId = merchantId;
            model.Id = 1;
            string a1 = JsonConvert.SerializeObject(model);

            string signStr = Signature.Compute(key, secret, timespan, a1);


            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("key", key);
            headers.Add("timestamp", timespan.ToString());
            headers.Add("sign", signStr);
            HttpUtil http = new HttpUtil();
            string result = http.HttpPostJson("http://localhost:1664/api/BankCard/Remove", a1, headers);

            return result;

        }

    }
}
