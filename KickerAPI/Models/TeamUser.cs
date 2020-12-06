using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickerAPI.Models
{
    public class TeamUser
    {
        public int TeamID { get; set; }
        public Team Team { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
