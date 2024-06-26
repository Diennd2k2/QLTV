﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using QLTV.Models;
using X.PagedList;

namespace QLTV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BookShelfsController : Controller
    {
        private PROJECT_QLTVContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IToastNotification _toastNotification;
        public BookShelfsController(PROJECT_QLTVContext context, IHttpContextAccessor httpContextAccessor, IToastNotification toastrNotification)
        {
            this.context = context;
            _httpContextAccessor = httpContextAccessor;
            _toastNotification = toastrNotification;
        }

        public IActionResult Index(string Search, int page = 1)
        {
            int limit = 5;
            var list = context.BookShelfs.OrderByDescending(c => c.CreateDate).ToPagedList(page, limit);
            if (!string.IsNullOrEmpty(Search))
            {
                list = context.BookShelfs.Where(x => x.IdBookShelf == int.Parse(Search) || x.NameBookShelf.Contains(Search) || x.DescribeNote.Contains(Search)).OrderByDescending(x => x.CreateDate).ToPagedList(page, limit);
            }
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
            return View(list);
        }

        public IActionResult Create()
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookShelfs model)
        {
            Boolean check = true;
            if (string.IsNullOrEmpty(model.NameBookShelf))
            {
                ViewBag.Name = "Tên kệ sách không được để trống";
                check = false;
            }

            var checkName = context.BookShelfs.FirstOrDefault(p => p.NameBookShelf.Equals(model.NameBookShelf));
            if (checkName != null)
            {
                ViewBag.CheckName = "Tên kệ sách đã tồn tại";
                check = false;
            }

            if (check)
            {
                model.IdUserCreate = 1;
                context.BookShelfs.Add(model);
                context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Thêm mới thành công");
                return RedirectToAction("Index");
            }
            else
            {
                var claims = _httpContextAccessor.HttpContext.User.Claims;
                var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
            BookShelfs bookShelfs = context.BookShelfs.FirstOrDefault(x => x.IdBookShelf == id);
            return View(bookShelfs);
        }

        [HttpPost]
        public IActionResult Edit(BookShelfs model)
        {
            Boolean check = true;
            if (string.IsNullOrEmpty(model.NameBookShelf))
            {
                ViewBag.Name = "Tên kệ sách không được để trống";
                check = false;
            }

            var checkName = context.BookShelfs.FirstOrDefault(x => x.NameBookShelf.Equals(model.NameBookShelf) && x.IdBookShelf.Equals(model.IdBookShelf) == false);
            if (checkName != null)
            {
                ViewBag.CheckName = "Tên kệ sách đã được sử dụng";
                check = false;
            }

            if (check)
            {
                context.BookShelfs.Update(model);
                context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Cập nhật thành công");
                return RedirectToAction("Index");
            }
            else
            {
                var claims = _httpContextAccessor.HttpContext.User.Claims;
                var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                ViewBag.User = context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
                BookShelfs bookShelfs = context.BookShelfs.FirstOrDefault(x => x.IdBookShelf == model.IdBookShelf);
                return View(bookShelfs);
            }
        }

        public IActionResult Delete(int id)
        {
            var checkBook = context.Books.FirstOrDefault(x => x.IdBookShelf == id);
            var data = context.BookShelfs.FirstOrDefault(x => x.IdBookShelf == id);
            if (checkBook != null)
            {
                _toastNotification.AddErrorToastMessage("Kệ sách đã được thêm sách không thể xoá");
                return RedirectToAction("Index");
            }
            if (data != null)
            {
                context.BookShelfs.Remove(data);
                context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Xóa thành công");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}