using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using QLTV.Models;

namespace QLTV.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginAdminController : Controller
    {
        private PROJECT_QLTVContext context;
        private readonly IToastNotification _toastNotification;

        public LoginAdminController(PROJECT_QLTVContext context, IToastNotification toastrNotification)
        {
            this.context = context;
            _toastNotification = toastrNotification;
        }

        public IActionResult Login(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(Accounts model)
        {
            if (string.IsNullOrEmpty(model.UserName) && string.IsNullOrEmpty(model.Password))
            {
                _toastNotification.AddErrorToastMessage("Vui lòng nhập tên đăng nhập và mật khẩu");
                return View();
            }
            else
            {
                var data = context.Accounts.SingleOrDefault(a => a.UserName == model.UserName && a.Password == model.Password && a.Status == 1);
                if (data != null)
                {
                    var identity = new ClaimsIdentity(new[] { 
                        new Claim(ClaimTypes.NameIdentifier, data.IdAccount.ToString()),
                        new Claim(ClaimTypes.Name, data.UserName),
                        new Claim(ClaimTypes.GivenName, data.FullName),
                        new Claim(ClaimTypes.Role, data.IdRole.ToString()),
                    }, "SecuritySchema");
                    var principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync("SecuritySchema", principal);
                    _toastNotification.AddSuccessToastMessage("Đăng nhập thành công");
                    return Redirect("/Admin/AdminHome/Index");
                }
                else
                {
                    _toastNotification.AddErrorToastMessage("Tài khoản hoặc mật khẩu không chính xác");
                    return View();
                }
            }
        }

        public IActionResult Logout()
        {
            var logout = HttpContext.SignOutAsync("QLTVSecurityScheme");
            HttpContext.Session.Remove("useradmin");
            _toastNotification.AddSuccessToastMessage("Đăng xuất thành công");
            return RedirectToAction("Login");
        }
    }
}