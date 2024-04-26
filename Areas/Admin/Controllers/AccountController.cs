using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLTV.Models;

namespace QLTV.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private PROJECT_QLTVContext context;

        public AccountController(PROJECT_QLTVContext context) => this.context = context;

        public IActionResult Index(string Search, int IdRole)
        {

            return View();
        }
    }
}