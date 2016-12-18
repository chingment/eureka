using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppApi.Models.Banner;
using Lumos.Entity;

namespace WebAppApi.Controllers
{
    public class BannerController:BaseApiController
    {
        [HttpGet]
        public APIResponse GetList(Enumeration.BannerType type)
        {
            var banner = CurrentDb.SysBanner.Where(m => m.Type == type).FirstOrDefault();
            if (banner == null)
            {
                return ResponseResult(ResultType.Failure, ResultCode.FailureNoData, "没有数据");
            }

            var bannerImages = CurrentDb.SysBannerImage.Where(m => m.BannerId == banner.Id).ToList();

            List<BannerImageModel> model = new List<BannerImageModel>();

            foreach (var m in bannerImages)
            {

                BannerImageModel imageModel = new BannerImageModel();
                imageModel.Id = m.Id;
                imageModel.Title = m.Title;
                imageModel.IsLink = m.IsLink;
                if (imageModel.IsLink)
                {
                    imageModel.Content = m.Content;
                }
                imageModel.ImgUrl = m.ImgUrl;
                model.Add(imageModel);
            }

            APIResult result = new APIResult() { Result = ResultType.Success, Code = ResultCode.Success, Message = "成功", Data = model };
            return new APIResponse(result);
        }

        [HttpGet]
        public APIResponse GetDetails(int id)
        {
            var bannerImage = CurrentDb.SysBannerImage.Where(m => m.Id == id).FirstOrDefault();
            if (bannerImage == null)
            {
                return ResponseResult(ResultType.Failure, ResultCode.FailureNoData, "没有数据");
            }

            BannerImageModel model = new BannerImageModel();
            model.Id = bannerImage.Id;
            model.Title = bannerImage.Title;
            model.Content = bannerImage.Content;
            model.ReadCount = bannerImage.ReadCount;
            model.ImgUrl = bannerImage.ImgUrl;

            APIResult result = new APIResult() { Result = ResultType.Success, Code = ResultCode.Success, Message = "成功", Data= model };
            return new APIResponse(result);
        }
    }
}