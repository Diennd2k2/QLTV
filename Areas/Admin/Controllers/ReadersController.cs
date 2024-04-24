using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLTV.Models;

namespace QLTV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ReadersController : Controller
    {
        private PROJECT_QLTVContext context;
        public ReadersController(PROJECT_QLTVContext context) => this.context = context;

        public IActionResult Index()
        {
            return View();
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
            var checkName = dataCheck.FirstOrDefault(p => p.PhoneReader.Equals(model.PhoneReader));
            if (checkName != null)
            {
                ViewBag.CheckPhone = "Số điện thoại độc giả đã tồn tại";
                check = false;
            }

            if (!string.IsNullOrEmpty(model.Passport))
            {
                var checkPassport = dataCheck.FirstOrDefault(x => x.Passport.Equals(model.Passport));
                if(checkPassport != null)
                {
                    ViewBag.Passport = "Số CCCD/CMT đã được sử dụng";
                }
                check = false;
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
    }
}