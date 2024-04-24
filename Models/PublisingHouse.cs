using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class PublisingHouse
    {
        public PublisingHouse()
        {
            Books = new HashSet<Books>();
        }

        public int IdPublisingHouse { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? IdUserCreate { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int? Status { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
