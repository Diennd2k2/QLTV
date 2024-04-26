using System;

namespace QLTV.Areas.Admin.Models
{
    public class ReadersModelView
    {
        public int IdReader { get; set; }
        public string NameReader { get; set; }
        public string AddressReader { get; set; }
        public string PhoneReader { get; set; }
        public string EmailReader { get; set; }
        public string Avatar { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Passport { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? isCard { get; set; }
    }
}
