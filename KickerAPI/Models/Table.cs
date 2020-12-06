using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickerAPI.Models
{
    public class Table
    {
        public int TableID { get; set; }
        public string TableName { get; set; }
        public string? CompanyName { get; set; }
        public string Address { get; set; }

        //Relations
        public User ContactPerson { get; set; }
        public int ContactPersonID { get; set; }

    }
}
