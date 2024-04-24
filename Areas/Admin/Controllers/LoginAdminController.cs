using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLTV.Models;

namespace QLTV.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginAdminController : Controller
    {
        private PROJECT_QLTVContext context;

        public LoginAdminController(PROJECT_QLTVContext context) => this.context = context;

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
                ViewBag.Erorr = "Vui lòng nhập email và mật khẩu!";
                return View();
            }
            else
            {
                var data = context.Accounts.SingleOrDefault(a => a.UserName == model.UserName && a.Password == model.Password && a.Status == 1);
                if (data != null)
                {
                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, data.UserName) }, "SecuritySchema");
                    var principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync("SecuritySchema", principal);
                    return Redirect("/Admin/AdminHome/Index");
                }
                else
                {
                    ViewBag.Erorr = "Sai tài khoản hoặc mật khẩu!";
                    return View();
                }
            }
        }

        public IActionResult Logout()
        {
            var logout = HttpContext.SignOutAsync("QLTVSecurityScheme");
            HttpContext.Session.Remove("useradmin");
            return RedirectToAction("Login");
        }
    }
}