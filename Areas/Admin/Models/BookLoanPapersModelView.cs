using QLTV.Models;
using System;
using System.Collections.Generic;

namespace QLTV.Areas.Admin.Models
{
    public class BookLoanPapersModelView
    {
        public int IdLoanPaper { get; set; }
        public string IdLibraryCard { get; set; }
        public int? IdReader { get; set; }
        public DateTime DateLoan { get; set; }
        public DateTime DatePay { get; set; }
        public int Status { get; set; }
        public int? IdUserCreate { get; set; }
        public DateTime? CreateDate { get; set; }
        public List<LoanPaperDetails> LoanPaperDetails { get; set; }
    }
}
