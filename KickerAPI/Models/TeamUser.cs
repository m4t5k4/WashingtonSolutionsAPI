using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KickerAPI.Models
{
    public class TeamUser
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int TeamID { get; set; }
        public Team Team { get; set; }
    }
}
