using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class Books
    {
        public Books()
        {
            LoanPaperDetails = new HashSet<LoanPaperDetails>();
        }

        public int IdBook { get; set; }
        public string NameBook { get; set; }
        public int? IdPublisingHouse { get; set; }
        public int? YearPublising { get; set; }
        public int? Quantitly { get; set; }
        public int? IdBookShelf { get; set; }
        public double Price { get; set; }
        public double LoanPrice { get; set; }
        public string UrlImage { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Status { get; set; }
        public int? IdUserCreate { get; set; }
        public string DescribeNote { get; set; }

        public BookShelfs IdBookShelfNavigation { get; set; }
        public PublisingHouse IdPublisingHouseNavigation { get; set; }
        public ICollection<LoanPaperDetails> LoanPaperDetails { get; set; }
    }
}
