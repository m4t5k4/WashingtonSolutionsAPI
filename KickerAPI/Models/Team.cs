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

        //Relations
        public Group Group { get; set; }
        public int GroupID { get; set; }
        public ICollection<TeamUser> TeamUsers { get; set; }
    }
}
