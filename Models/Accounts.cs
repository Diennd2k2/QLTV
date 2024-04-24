using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class Accounts
    {
        public int IdAccount { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? CreateDate { get; set; }
        public string FullName { get; set; }
        public int? IdUserCreate { get; set; }
        public int? Status { get; set; }
        public int? IdRole { get; set; }
        public string Avatar { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public Roles IdRoleNavigation { get; set; }
    }
}
