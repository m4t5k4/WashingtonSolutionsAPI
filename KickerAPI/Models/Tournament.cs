using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickerAPI.Models
{
    public class Tournament
    {
        public int TournamentID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Relations
        public Competition Competition { get; set; }
        public int CompetitionID { get; set; }
        public Group? Winner { get; set; }
        public int? WinnerID { get; set; }

    }
}
