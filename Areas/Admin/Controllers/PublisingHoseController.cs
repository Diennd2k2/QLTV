using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLTV.Models;
using X.PagedList;

namespace QLTV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PublisingHoseController : Controller
    {
        private PROJECT_QLTVContext context;

        public PublisingHoseController(PROJECT_QLTVContext context) => this.context = context;

        public IActionResult Index(string Search, int page = 1)
        {
            int limit = 5;
            var list = context.PublisingHouse.OrderByDescending(c => c.CreateDate).ToPagedList(page, limit);
            if (!string.IsNullOrEmpty(Search))
            {
                list = context.PublisingHouse.Where(x => x.IdPublisingHouse == int.Parse(Search) || x.Name.Contains(Search) || x.Address.Contains(Search) || x.Country.Contains(Search)).OrderByDescending(x => x.CreateDate).ToPagedList(page, limit);
            }
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PublisingHouse model)
        {
            Boolean check = true;
            if (string.IsNullOrEmpty(model.Name))
            {
                ViewBag.Name = "Tên nhà xuất bản không được để trống";
                check = false;
            }

            var checkName = context.PublisingHouse.FirstOrDefault(p => p.Name.Equals(model.Name));
            if (checkName != null)
            {
                ViewBag.CheckName = "Tên nhà xuất bản đã tồn tại";
                check = false;
            }

            if (check)
            {
                model.IdUserCreate = 1;
                context.PublisingHouse.Add(model);
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
            PublisingHouse publisingHouse = context.PublisingHouse.FirstOrDefault(x => x.IdPublisingHouse == id);
            return View(publisingHouse);
        }

        [HttpPost]
        public IActionResult Edit(PublisingHouse model)
        {
            Boolean check = true;
            if (string.IsNullOrEmpty(model.Name))
            {
                ViewBag.Name = "Tên nhà xuất bản không được để trống";
                check = false;
            }

            var checkName = context.BookShelfs.FirstOrDefault(x => x.NameBookShelf.Equals(model.Name) && x.IdBookShelf.Equals(model.IdPublisingHouse) == false);
            if (checkName != null)
            {
                ViewBag.CheckName = "Tên nhà xuất bản đã tồn tại";
                check = false;
            }

            if (check)
            {
                context.PublisingHouse.Update(model);
                context.SaveChanges();
                TempData["success"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }
            else
            {
                PublisingHouse publisingHouse = context.PublisingHouse.FirstOrDefault(x => x.IdPublisingHouse == model.IdPublisingHouse);
                return View(publisingHouse);
            }
        }

        public IActionResult Delete(int id)
        {
            var checkBook = context.Books.FirstOrDefault(x => x.IdPublisingHouse == id);
            var data = context.PublisingHouse.FirstOrDefault(x => x.IdPublisingHouse == id);
            if (checkBook != null)
            {
                TempData["eror"] = "Nhà xuất bản đã được thêm sách không thể xoá!";
                return RedirectToAction("Index");
            }
            if (data != null)
            {
                context.PublisingHouse.Remove(data);
                context.SaveChanges();
                TempData["success"] = "Xóa thành công";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}