using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using QLTV.Areas.Admin.Models;
using QLTV.Models;
using System;
using System.Linq;

namespace QLTV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BookLoanPapersController : Controller
    {
        private PROJECT_QLTVContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IToastNotification _toastNotification;
        public BookLoanPapersController(PROJECT_QLTVContext context, IHttpContextAccessor httpContextAccessor, IToastNotification toastrNotification)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _toastNotification = toastrNotification;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var libraryCards = _context.LibraryCards.ToList();
            var books = _context.Books.ToList();
            var readers = _context.Readers.ToList();
            ViewBag.LibraryCards = libraryCards;
            ViewBag.Books = books;
            ViewBag.Readers = readers;

            return View();
        }

        [HttpPost]
        public IActionResult Create(BookLoanPapersModelView model)
        {
            //if (ModelState.IsValid)
            //{
            //    var loanPaper = new BookLoanPapers
            //    {
            //        IdLibraryCard = model.IdLibraryCard,
            //        IdReader = model.IdReader,
            //        DateLoan = model.DateLoan,
            //        DatePay = model.DatePay,
            //        Status = model.Status,
            //        IdUserCreate = model.IdUserCreate
            //    };

            //    _context.BookLoanPapers.Add(loanPaper);
            //    _context.SaveChanges();
            //    foreach (var book in model.LoanPaperDetails)
            //    {
            //        var loanDetail = new LoanPaperDetails
            //        {
            //            IdLoanPaper = loanPaper.IdLoanPaper,
            //            IdBook = book.IdBook,
            //            Quantity = book.Quantity,
            //            Depositis = book.Depositis,
            //            LoanPrice = book.LoanPrice
            //        };

            //        _context.LoanPaperDetails.Add(loanDetail);
            //    }
            //    _context.SaveChanges();

            //    return RedirectToAction("Index");
            //}

            return null;
        }

    }
}
