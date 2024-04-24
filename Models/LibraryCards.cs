using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class LibraryCards
    {
        public LibraryCards()
        {
            BookLoanPapers = new HashSet<BookLoanPapers>();
        }

        public string IdLibraryCard { get; set; }
        public int? IdReader { get; set; }
        public string Avrtar { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Passport { get; set; }
        public string FullName { get; set; }
        public int? IdUserCreate { get; set; }
        public DateTime? CreateDate { get; set; }

        public Readers IdReaderNavigation { get; set; }
        public ICollection<BookLoanPapers> BookLoanPapers { get; set; }
    }
}
