using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using QLTV.Areas.Admin.Models;
using QLTV.Models;
using System;
using System.Linq;
using System.Security.Claims;

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
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewBag.User = _context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));
            return View();
        }

        public IActionResult Create()
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            ViewBag.User = _context.Accounts.FirstOrDefault(x => x.IdAccount == Int32.Parse(idUsse));

            var libraryCards = _context.LibraryCards.ToList();
            var books = _context.Books.ToList();
            var readers = _context.Readers.ToList();
            ViewBag.LibraryCards = libraryCards;
            ViewBag.Books = books;
            ViewBag.Readers = readers;

            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookLoanPapersModelView model)
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var idUsse = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var libraryCard = _context.LibraryCards.FirstOrDefault(x => x.IdLibraryCard == model.IdLibraryCard);
            if (ModelState.IsValid)
            {
                var loanPaper = new BookLoanPapers
                {
                    IdLibraryCard = model.IdLibraryCard,
                    IdReader = libraryCard.IdReader,
                    DateLoan = model.DateLoan,
                    DatePay = model.DatePay,
                    Status = 1,
                    IdUserCreate = int.Parse(idUsse),
                };

                _context.BookLoanPapers.Add(loanPaper);
                _context.SaveChanges();
                foreach (var book in model.LoanPaperDetails)
                {
                    var loanDetail = new LoanPaperDetails
                    {
                        IdLoanPaper = loanPaper.IdLoanPaper,
                        IdBook = book.IdBook,
                        Quantity = book.Quantity,
                        Depositis = book.Depositis,
                        LoanPrice = book.LoanPrice
                    };

                    _context.LoanPaperDetails.Add(loanDetail);
                }
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}
