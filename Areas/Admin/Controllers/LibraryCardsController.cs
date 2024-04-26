using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLTV.Models;
using System.IO;
using System;
using System.Linq;
using System.Security.Claims;
using NToastNotify;

namespace QLTV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class LibraryCardsController : Controller
    {
        private PROJECT_QLTVContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IToastNotification _toastNotification;
        public LibraryCardsController(PROJECT_QLTVContext context, IHttpContextAccessor httpContextAccessor, IToastNotification toastrNotification)
        {
            this.context = context;
            _httpContextAccessor = httpContextAccessor;
            _toastNotification = toastrNotification;
        }

        public IActionResult Create(int idReader)
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
            Readers data = context.Readers.FirstOrDefault(x => x.IdReader == idReader);
            return View(data);
        }

        [HttpPost]
        public IActionResult Create(LibraryCards model)
        {
            Boolean check = true;
            var dataCheck = context.LibraryCards.ToList();
            if (string.IsNullOrEmpty(model.IdLibraryCard))
            {
                ViewBag.IdLibraryCard1 = "Mã thẻ không được để trống";
                check = false;
            }
            if (!string.IsNullOrEmpty(model.IdLibraryCard))
            {
                var checkIdCard = dataCheck.FirstOrDefault(p => p.IdLibraryCard.Equals(model.IdLibraryCard));
                if (checkIdCard != null)
                {
                    ViewBag.IdLibraryCard2 = "Mã thẻ đã tồn tại";
                    check = false;
                }
            }
            if (string.IsNullOrEmpty(model.FullName))
            {
                ViewBag.Name = "Tên độc giả không được để trống";
                check = false;
            }

            if (string.IsNullOrEmpty(model.Passport))
            {
                ViewBag.Passport = "Số CMT, CCCD không được để trống";
                check = false;
            }

            if (!string.IsNullOrEmpty(model.Passport))
            {
                var checkPassport = dataCheck.FirstOrDefault(x => x.Passport.Equals(model.Passport));
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
                    model.Avrtar = FileName; // gán tên ảnh cho thuộc tinh Image
                }
            }

            if (check)
            {
                var idCreate = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                model.IdUserCreate = int.Parse(idCreate);
                context.LibraryCards.Add(model);
                context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Thêm mới thành công");
                return RedirectToAction("Index", "Readers");
            }
            else
            {
                var claims = _httpContextAccessor.HttpContext.User.Claims;
                var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
                return View();
            }
        }

        public IActionResult Detail(int idReader)
        {
            LibraryCards data = context.LibraryCards.FirstOrDefault(x => x.IdReader == idReader);
            return View(data);
        }
    }
}
