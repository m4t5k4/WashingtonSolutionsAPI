using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickerAPI.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }

        //Relations
        public User Captain { get; set; }
        public int CaptainUserID { get; set; }
        public ICollection<TeamUser> TeamUsers { get; set; }
    }
}
