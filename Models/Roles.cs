using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Accounts = new HashSet<Accounts>();
        }

        public int IdRole { get; set; }
        public string NameRole { get; set; }
        public int? Status { get; set; }

        public ICollection<Accounts> Accounts { get; set; }
    }
}
