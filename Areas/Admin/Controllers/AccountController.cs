using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using QLTV.Models;
using X.PagedList;

namespace QLTV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AccountController : Controller
    {
        private PROJECT_QLTVContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IToastNotification _toastNotification;
        public AccountController(PROJECT_QLTVContext context, IHttpContextAccessor httpContextAccessor, IToastNotification toastrNotification)
        {
            this.context = context;
            _httpContextAccessor = httpContextAccessor;
            _toastNotification = toastrNotification;
        }

        public IActionResult Index(string Search, int IdRole, int page = 1)
        {
            int limit = 5;
            var list = context.Accounts.Include(x => x.IdRoleNavigation).ToList();
            if (!string.IsNullOrEmpty(Search))
            {
                list = list.Where(x => x.UserName.Contains(Search) || x.FullName.Contains(Search)).ToList();
            }
            if(IdRole > 0)
            {
                list = list.Where(x => x.IdRole == IdRole).ToList();
            }
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
            ViewBag.listRole = context.Roles.ToList();
            return View(list.OrderByDescending(x => x.CreateDate).ToPagedList(page, limit));
        }

        public IActionResult Create()
        {
            ViewBag.listRole = context.Roles.Where(x => x.Status == 1).ToList();
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
            return View();
        }

        [HttpPost]
        public IActionResult Create(Accounts model)
        {
            Boolean check = true;
            var dataCheck = context.Accounts.ToList();
            if (string.IsNullOrEmpty(model.UserName))
            {
                ViewBag.UserName = "Tên đăng nhập không được để trống";
                check = false;
            }

            if (!string.IsNullOrEmpty(model.UserName))
            {
                var checkUserName = dataCheck.FirstOrDefault(p => p.UserName.Equals(model.UserName));
                if(checkUserName != null)
                {
                    ViewBag.UserNameEq = "Tên đăng nhập đã được sử dụng";
                    check = false;
                }
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                ViewBag.Password = "Mật khẩu không được để trống";
                check = false;
            }

            if (string.IsNullOrEmpty(model.FullName))
            {
                ViewBag.FullName = "Nhập tên nhân viên";
                check = false;
            }

            if (model.IdRole == 0)
            {
                ViewBag.Role = "Vui lòng chọn chức vụ";
                check = false;
            }

            var files = HttpContext.Request.Form.Files;
            if (files.Count() > 0 && files[0].Length > 0)
            {
                var file = files[0];
                var FileName = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Accounts", FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    model.Avatar = FileName; // gán tên ảnh cho thuộc tinh Image
                }
            }

            if (check)
            {
                var claims = _httpContextAccessor.HttpContext.User.Claims;
                var idUsseCreate = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                model.IdUserCreate = Int32.Parse(idUsseCreate);
                context.Accounts.Add(model);
                context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Thêm mới thành công");
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.listRole = context.Roles.Where(x => x.Status == 1).ToList();
                var claims = _httpContextAccessor.HttpContext.User.Claims;
                var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            ViewBag.listRole = context.Roles.Where(x => x.Status == 1).ToList();
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
            Accounts data = context.Accounts.FirstOrDefault(x => x.IdAccount == id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Accounts model)
        {
            Boolean check = true;
            var dataCheck = context.Accounts.ToList();
            if (string.IsNullOrEmpty(model.UserName))
            {
                ViewBag.UserName = "Tên đăng nhập không được để trống";
                check = false;
            }

            if (!string.IsNullOrEmpty(model.UserName))
            {
                var checkUserName = dataCheck.FirstOrDefault(p => p.UserName.Equals(model.UserName) && p.IdAccount != model.IdAccount);
                if (checkUserName != null)
                {
                    ViewBag.UserNameEq = "Tên đăng nhập đã được sử dụng";
                    check = false;
                }
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                ViewBag.Password = "Mật khẩu không được để trống";
                check = false;
            }

            if (string.IsNullOrEmpty(model.FullName))
            {
                ViewBag.FullName = "Nhập tên nhân viên";
                check = false;
            }

            if (model.IdRole == 0)
            {
                ViewBag.Role = "Vui lòng chọn chức vụ";
                check = false;
            }

            var files = HttpContext.Request.Form.Files;
            if (files.Count() > 0 && files[0].Length > 0)
            {
                var file = files[0];
                var FileName = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Accounts", FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    model.Avatar = FileName; // gán tên ảnh cho thuộc tinh Image
                }
            }

            if (check)
            {
                context.Accounts.Update(model);
                context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Cập nhật thành công");
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.listRole = context.Roles.Where(x => x.Status == 1).ToList();
                var claims = _httpContextAccessor.HttpContext.User.Claims;
                var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
                Accounts data = context.Accounts.FirstOrDefault(x => x.IdAccount == model.IdAccount);
                return View(data);
            }
        }

        public IActionResult Delete(int id)
        {
            var data = context.Accounts.FirstOrDefault(x => x.IdAccount == id);
            if (data != null)
            {
                context.Accounts.Remove(data);
                context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Xóa thành công");
                return RedirectToAction("Index");
            }
            else
            {
                _toastNotification.AddErrorToastMessage("Có lỗi xảy ra");
            }
            return RedirectToAction("Index");
        }
    }
}