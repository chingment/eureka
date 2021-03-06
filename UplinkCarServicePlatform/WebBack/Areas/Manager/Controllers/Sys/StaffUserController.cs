﻿using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Lumos.Entity;
using Lumos.DAL.AuthorizeRelay;
using Lumos.Common;
using WebBack.Areas.Manager.Models.Sys.StaffUser;
using Lumos.Mvc;

namespace WebBack.Areas.Manager.Controllers
{
    [ManagerAuthorize(PermissionCode.后台用户管理)]
    public class StaffUserController : ManagerController
    {

        #region 视图

        public ViewResult List()
        {
            return View();
        }

        public ViewResult Add()
        {
            AddViewModel model = new AddViewModel();
            return View();
        }

        public ViewResult Edit(int id)
        {
            EditViewModel model =new EditViewModel(id);
            return View(model);
        }
        #endregion

        public JsonResult GetList(StaffUserSearchCondition condition)
        {
            var list = (from u in CurrentDb.SysStaffUser
                        where (condition.UserName == null || u.UserName.Contains(condition.UserName)) &&
                        (condition.FullName == null || u.FullName.Contains(condition.FullName)) &&
                        u.IsDelete == false
                        select new { u.Id, u.UserName, u.FullName, u.Email, u.PhoneNumber, u.CreateTime, u.IsDelete });

            int total = list.Count();

            int pageIndex = condition.PageIndex;
            int pageSize = 10;
            list = list.OrderByDescending(r => r.CreateTime).Skip(pageSize * (pageIndex)).Take(pageSize);

            PageEntity pageEntity = new PageEntity { PageSize = pageSize, TotalRecord = total, Rows = list };

            return Json(ResultType.Success, pageEntity, "");
        }

        public JsonResult GetUserRoleTree(int userId = 0)
        {
            var isCheckedIds = CurrentDb.SysUserRole.Where(x => x.UserId == userId).Select(x => x.RoleId);
            object json = ConvertToZTreeJson2(CurrentDb.Roles.ToArray(), "id", "pid", "name", "role", isCheckedIds.ToArray());

            return Json(ResultType.Success, json);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Add(AddViewModel model)
        {

            SysStaffUser user = new SysStaffUser();
            user.UserName = model.SysStaffUser.UserName;
            user.FullName = model.SysStaffUser.FullName;
            user.PasswordHash = model.SysStaffUser.PasswordHash;
            user.Email = model.SysStaffUser.Email;
            user.IsModifyDefaultPwd = false;
            user.IsDelete = false;
            user.Status = Enumeration.UserStatus.Normal;
            user.Creator = User.Identity.GetUserId<int>();
            user.CreateTime = DateTime.Now;
            int[] userRoleIds = model.UserRoleIds;


            var identiy = new AspNetIdentiyAuthorizeRelay<SysStaffUser>();


            if (identiy.UserExists(user.UserName.Trim()))
                return Json(ResultType.Failure, ManagerOperateTipUtils.USER_EXISTS);


            bool r = identiy.CreateUser(user, model.UserRoleIds);
            if (!r)
                return Json(ResultType.Failure, ManagerOperateTipUtils.ADD_FAILURE);



            return Json(ResultType.Success, ManagerOperateTipUtils.ADD_SUCCESS);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(EditViewModel model)
        {

            var identiy = new AspNetIdentiyAuthorizeRelay<SysStaffUser>();
            SysStaffUser user = identiy.GetUser(model.SysStaffUser.Id);

            user.FullName = model.SysStaffUser.FullName;
            user.Email = model.SysStaffUser.Email;
            user.PhoneNumber = model.SysStaffUser.PhoneNumber;
            user.Mender = User.Identity.GetUserId<int>();
            user.LastUpdateTime = DateTime.Now;
            int[] userRoleIds = model.UserRoleIds;

            bool r = identiy.UpdateUser(user, model.SysStaffUser.PasswordHash, model.UserRoleIds);
            if (!r)
            {
                return Json(ResultType.Failure, ManagerOperateTipUtils.UPDATE_FAILURE);
            }
            return Json(ResultType.Success, ManagerOperateTipUtils.UPDATE_SUCCESS);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int[] userIds)
        {

            var identiy = new AspNetIdentiyAuthorizeRelay<SysStaffUser>();

            var reusult = identiy.DeleteUser(this.CurrentUserId,userIds);

            if (!reusult)
            {
                return Json(ResultType.Failure, ManagerOperateTipUtils.DELETE_FAILURE);
            }

            return Json(ResultType.Success, ManagerOperateTipUtils.DELETE_SUCCESS);
        }


      
    }
}