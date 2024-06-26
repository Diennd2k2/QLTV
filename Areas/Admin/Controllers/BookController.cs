﻿using System;
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
    public class BookController : Controller
    {
        private PROJECT_QLTVContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IToastNotification _toastNotification;
        public BookController(PROJECT_QLTVContext context, IHttpContextAccessor httpContextAccessor, IToastNotification toastrNotification)
        {
            this.context = context;
            _httpContextAccessor = httpContextAccessor;
            _toastNotification = toastrNotification;
        }

        public IActionResult Index(string Search, int IdBookShelfs, int IdPublisingHose, int page = 1)
        {
            int limit = 5;
            var list = context.Books.Include(x => x.IdBookShelfNavigation).Include(p => p.IdPublisingHouseNavigation).ToList();
            if (!string.IsNullOrEmpty(Search))
            {
                list = list.Where(x => x.NameBook.Contains(Search) || x.DescribeNote.Contains(Search)).ToList();
            }
            if(IdBookShelfs > 0)
            {
                list = list.Where(x => x.IdBookShelf == IdBookShelfs).ToList();
            }
            if(IdPublisingHose > 0)
            {
                list = list.Where(x => x.IdPublisingHouse == IdBookShelfs).ToList();
            }
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
            var listBookShelfs = context.BookShelfs.OrderByDescending(x => x.CreateDate).ToList();
            ViewBag.listBookShelfs = listBookShelfs;
            var listPublisingHose = context.PublisingHouse.OrderByDescending(x => x.CreateDate).ToList();
            ViewBag.listPublisingHose = listPublisingHose;
            return View(list.OrderByDescending(x => x.CreateDate).ToPagedList(page, limit));
        }

        public IActionResult Create()
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
            var listBookShelfs = context.BookShelfs.Where(x => x.Status == 1).ToList();
            ViewBag.listBookShelfs = listBookShelfs;
            var listPublisingHose = context.PublisingHouse.Where(x => x.Status == 1).ToList();
            ViewBag.listPublisingHose = listPublisingHose;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Books model)
        {
            Boolean check = true;
            if (string.IsNullOrEmpty(model.NameBook))
            {
                ViewBag.Name = "Tên sách không được để trống";
                check = false;
            }

            var checkId = context.Books.FirstOrDefault(x => x.NameBook == model.NameBook);
            if (checkId != null)
            {
                ViewBag.CheckName = "Tên sách đã tồn tại";
                check = false;
            }

            if (model.Quantitly <= 0)
            {
                ViewBag.Quantitly = "Vui lòng nhập số lượng";
                check = false;
            }

            if (model.Price <= 0)
            {
                ViewBag.Price = "Vui lòng nhập giá mua";
                check = false;
            }

            if (model.LoanPrice <= 0)
            {
                ViewBag.LoanPrice = "Vui lòng nhập giá cho thuê";
                check = false;
            }

            if (model.LoanPrice > 0 && model.LoanPrice >= model.Price)
            {
                ViewBag.LoanPriceCheck = "Vui lòng nhập giá cho thuê phải nhỏ hơn giá mua";
                check = false;
            }

            if (model.IdBookShelf == 0)
            {
                ViewBag.BookShelf = "Vui lòng chọn vị trí kệ";
                check = false;
            }

            if (model.IdPublisingHouse == 0)
            {
                ViewBag.PublisingHouse = "Vui lòng chọn nhà xuất bản";
                check = false;
            }
           
            var files = HttpContext.Request.Form.Files;
            if (files.Count() > 0 && files[0].Length > 0)
            {
                var file = files[0];
                var FileName = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Books", FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    model.UrlImage = FileName; // gán tên ảnh cho thuộc tinh Image
                }
            }
            else
            {
                ViewBag.Image = "Vui lòng chọn ảnh";
                check = false;
            }

            if (check)
            {
                context.Books.Add(model);
                context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Thêm mới thành công");
                return RedirectToAction("Index");
            }
            else
            {
                var claims = _httpContextAccessor.HttpContext.User.Claims;
                var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
                var listBookShelfs = context.BookShelfs.Where(x => x.Status == 1).ToList();
                ViewBag.listBookShelfs = listBookShelfs;
                var listPublisingHose = context.PublisingHouse.Where(x => x.Status == 1).ToList();
                ViewBag.listPublisingHose = listPublisingHose;
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
            Books data = context.Books.FirstOrDefault(x => x.IdBook == id);
            var listBookShelfs = context.BookShelfs.Where(x => x.Status == 1).ToList();
            ViewBag.listBookShelfs = listBookShelfs;
            var listPublisingHose = context.PublisingHouse.Where(x => x.Status == 1).ToList();
            ViewBag.listPublisingHose = listPublisingHose;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Books model)
        {
            Boolean check = true;
            if (string.IsNullOrEmpty(model.NameBook))
            {
                ViewBag.Name = "Tên sách không được để trống";
                check = false;
            }

            var checkId = context.Books.FirstOrDefault(x => x.NameBook == model.NameBook && x.IdBook != model.IdBook);
            if (checkId != null)
            {
                ViewBag.CheckName = "Tên sách đã tồn tại";
                check = false;
            }

            if (model.Quantitly <= 0)
            {
                ViewBag.Quantitly = "Vui lòng nhập số lượng";
                check = false;
            }

            if (model.Price <= 0)
            {
                ViewBag.Price = "Vui lòng nhập giá mua";
                check = false;
            }

            if (model.LoanPrice <= 0)
            {
                ViewBag.LoanPrice = "Vui lòng nhập giá cho thuê";
                check = false;
            }

            if (model.LoanPrice > 0 && model.LoanPrice >= model.Price)
            {
                ViewBag.LoanPriceCheck = "Vui lòng nhập giá cho thuê phải nhỏ hơn giá mua";
                check = false;
            }

            if (model.IdBookShelf == 0)
            {
                ViewBag.BookShelf = "Vui lòng chọn vị trí kệ";
                check = false;
            }

            if (model.IdPublisingHouse == 0)
            {
                ViewBag.PublisingHouse = "Vui lòng chọn nhà xuất bản";
                check = false;
            }

            var files = HttpContext.Request.Form.Files;
            if (files.Count() > 0 && files[0].Length > 0)
            {
                var file = files[0];
                var FileName = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Books", FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    model.UrlImage = FileName; // gán tên ảnh cho thuộc tinh Image
                }
            }

            if (check)
            {
                context.Books.Update(model);
                context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Cập nhật thành công");
                return RedirectToAction("Index");
            }
            else
            {
                var claims = _httpContextAccessor.HttpContext.User.Claims;
                var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
                Books data = context.Books.FirstOrDefault(x => x.IdBook == model.IdBook);
                var listBookShelfs = context.BookShelfs.Where(x => x.Status == 1).ToList();
                ViewBag.listBookShelfs = listBookShelfs;
                var listPublisingHose = context.PublisingHouse.Where(x => x.Status == 1).ToList();
                ViewBag.listPublisingHose = listPublisingHose;
                return View(data);
            }
        }

        public IActionResult Delete(int id)
        {
            var checkBook = context.LoanPaperDetails.FirstOrDefault(x => x.IdBook == id);
            var data = context.Books.FirstOrDefault(x => x.IdBook == id);
            if (checkBook != null)
            {
                _toastNotification.AddErrorToastMessage("Sách đã được mượn không thể xoá");
                return RedirectToAction("Index");
            }
            if (data != null)
            {
                context.Books.Remove(data);
                context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Xóa thành công");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}