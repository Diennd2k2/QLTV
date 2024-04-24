using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class Readers
    {
        public Readers()
        {
            BookLoanPapers = new HashSet<BookLoanPapers>();
            LibraryCards = new HashSet<LibraryCards>();
            LoanPaperDetails = new HashSet<LoanPaperDetails>();
        }

        public int IdReader { get; set; }
        public string NameReader { get; set; }
        public string AddressReader { get; set; }
        public string PhoneReader { get; set; }
        public string EmailReader { get; set; }
        public string Avatar { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Passport { get; set; }
        public DateTime? CreateDate { get; set; }

        public ICollection<BookLoanPapers> BookLoanPapers { get; set; }
        public ICollection<LibraryCards> LibraryCards { get; set; }
        public ICollection<LoanPaperDetails> LoanPaperDetails { get; set; }
    }
}
