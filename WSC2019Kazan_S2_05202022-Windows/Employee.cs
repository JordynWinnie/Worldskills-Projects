using System;
using System.Collections.Generic;

namespace WSC2019Kazan_S5_05202022_Windows
{
    public partial class Employee
    {
        public Employee()
        {
            Assets = new HashSet<Asset>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public bool? IsAdmin { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
    }
}
