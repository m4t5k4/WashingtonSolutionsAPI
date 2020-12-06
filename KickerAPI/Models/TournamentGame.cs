using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickerAPI.Models
{
    public class TournamentGame
    {
        public int TournamentID { get; set; }
        public Tournament Tournament { get; set; }
        public int GameID { get; set; }
        public Game Game { get; set; }
    }
}
