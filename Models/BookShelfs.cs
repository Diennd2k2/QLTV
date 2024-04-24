using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class BookShelfs
    {
        public BookShelfs()
        {
            Books = new HashSet<Books>();
        }

        public int IdBookShelf { get; set; }
        public string NameBookShelf { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? IdUserCreate { get; set; }
        public string DescribeNote { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
