using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLTV.Models;
using X.PagedList;

namespace QLTV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ReadersController : Controller
    {
        private PROJECT_QLTVContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ReadersController(PROJECT_QLTVContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index(string Search, int page = 1)
        {
            int limit = 5;
            var list = context.Readers.ToList();
            if (!string.IsNullOrEmpty(Search))
            {
                list = list.Where(x => x.NameReader.Contains(Search) || x.PhoneReader.Contains(Search) || x.EmailReader.Contains(Search) || x.Passport.Contains(Search)).ToList();
            }
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var userName = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            ViewBag.UserName = userName;
            return View(list.OrderByDescending(x => x.CreateDate).ToPagedList(page, limit));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Readers model)
        {
            Boolean check = true;
            var dataCheck = context.Readers.ToList();
            if (string.IsNullOrEmpty(model.NameReader))
            {
                ViewBag.Name = "Tên độc giả không được để trống";
                check = false;
            }

            if (string.IsNullOrEmpty(model.PhoneReader))
            {
                ViewBag.Phone = "Số điện thoại độc giả không được để trống";
                check = false;
            }
            if (!string.IsNullOrEmpty(model.PhoneReader))
            {
                var checkName = dataCheck.FirstOrDefault(p => p.PhoneReader.Equals(model.PhoneReader));
                if (checkName != null)
                {
                    ViewBag.CheckPhone = "Số điện thoại độc giả đã tồn tại";
                    check = false;
                }
            }

            if (!string.IsNullOrEmpty(model.EmailReader))
            {
                var checkEmail = dataCheck.FirstOrDefault(x => x.EmailReader.Equals(model.EmailReader));
                if (checkEmail != null)
                {
                    ViewBag.CheckEmail = "Địa chỉ email đã tồn tại";
                    check = false;
                }
            }

            if (string.IsNullOrEmpty(model.Passport))
            {
                ViewBag.Passport = "Số CMT, CCCD không được để trống";
                check = false;
            }

            if (!string.IsNullOrEmpty(model.Passport))
            {
                var checkPassport = dataCheck.FirstOrDefault(x => x.Passport.Equals(model.Passport));
                if(checkPassport != null)
                {
                    ViewBag.CheckPassport = "Số CCCD/CMT đã được sử dụng";
                    check = false;
                }
            }

            if (model.DateOfBirth == null)
            {
                ViewBag.DateOfBirth = "Ngày sinh không được để trống";
                check = false;
            }

            var files = HttpContext.Request.Form.Files;
            if (files.Count() > 0 && files[0].Length > 0)
            {
                var file = files[0];
                var FileName = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Avatars", FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    model.Avatar = FileName; // gán tên ảnh cho thuộc tinh Image
                }
            }

            if (check)
            {
                context.Readers.Add(model);
                context.SaveChanges();
                TempData["success"] = "Thêm mới thành công";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            Readers data = context.Readers.FirstOrDefault(x => x.IdReader == id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Readers model)
        {
            Boolean check = true;
            var dataCheck = context.Readers.ToList();
            if (string.IsNullOrEmpty(model.NameReader))
            {
                ViewBag.Name = "Tên độc giả không được để trống";
                check = false;
            }

            if (string.IsNullOrEmpty(model.PhoneReader))
            {
                ViewBag.Phone = "Số điện thoại độc giả không được để trống";
                check = false;
            }
            if (!string.IsNullOrEmpty(model.PhoneReader))
            {
                var checkName = dataCheck.FirstOrDefault(p => p.PhoneReader.Equals(model.PhoneReader) && p.IdReader != model.IdReader);
                if (checkName != null)
                {
                    ViewBag.CheckPhone = "Số điện thoại độc giả đã tồn tại";
                    check = false;
                }
            }

            if (!string.IsNullOrEmpty(model.EmailReader))
            {
                var checkEmail = dataCheck.FirstOrDefault(x => x.EmailReader.Equals(model.EmailReader) && x.IdReader != model.IdReader);
                if (checkEmail != null)
                {
                    ViewBag.CheckEmail = "Địa chỉ email đã tồn tại";
                    check = false;
                }
            }

            if (string.IsNullOrEmpty(model.Passport))
            {
                ViewBag.Passport = "Số CMT, CCCD không được để trống";
                check = false;
            }

            if (!string.IsNullOrEmpty(model.Passport))
            {
                var checkPassport = dataCheck.FirstOrDefault(x => x.Passport.Equals(model.Passport) && x.IdReader != model.IdReader);
                if (checkPassport != null)
                {
                    ViewBag.CheckPassport = "Số CCCD/CMT đã được sử dụng";
                    check = false;
                }
            }

            if (model.DateOfBirth == null)
            {
                ViewBag.DateOfBirth = "Ngày sinh không được để trống";
                check = false;
            }

            var files = HttpContext.Request.Form.Files;
            if (files.Count() > 0 && files[0].Length > 0)
            {
                var file = files[0];
                var FileName = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Avatars", FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    model.Avatar = FileName; // gán tên ảnh cho thuộc tinh Image
                }
            }

            if (check)
            {
                context.Readers.Update(model);
                context.SaveChanges();
                TempData["success"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }
            else
            {
                Readers data = context.Readers.FirstOrDefault(x => x.IdReader == model.IdReader);

                return View(data);
            }
        }

        public IActionResult Delete(int id)
        {
            var data = context.Readers.FirstOrDefault(x => x.IdReader == id);
            if (data != null)
            {
                context.Readers.Remove(data);
                context.SaveChanges();
                TempData["success"] = "Xóa thành công";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}