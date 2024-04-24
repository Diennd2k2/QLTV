using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class LoanPaperDetails
    {
        public int IdLoanPaperDetail { get; set; }
        public int? IdLoanPaper { get; set; }
        public int? IdBook { get; set; }
        public double Depositis { get; set; }
        public double LoanPrice { get; set; }
        public DateTime? CreateDate { get; set; }
        public int Quantity { get; set; }

        public Books IdBookNavigation { get; set; }
        public Readers IdLoanPaperNavigation { get; set; }
    }
}
