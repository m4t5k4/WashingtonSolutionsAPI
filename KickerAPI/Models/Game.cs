using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickerAPI.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public int ScoreTeamA { get; set; }
        public int ScoreTeamB { get; set; }
        public DateTime Date { get; set; }

        //Relations
        public Team? TeamA { get; set; }
        public int? TeamAID { get; set; }
        public Team? TeamB { get; set; }
        public int? TeamBID { get; set; }
        public Table Table { get; set; }
        public int TableID { get; set; }

    }
}
