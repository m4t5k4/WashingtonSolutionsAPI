using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickerAPI.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public int? ScoreTeamA { get; set; }
        public int? ScoreTeamB { get; set; }
        public DateTime Date { get; set; }

        //Relations
        public Team? TeamA { get; set; }
        public int? TeamAID { get; set; }
        public Team? TeamB { get; set; }
        public int? TeamBID { get; set; }
        public Table? Table { get; set; }
        public int? TableID { get; set; }
        public GameType? GameType { get; set; }
        public int? GameTypeID { get; set; }
        public Tournament? Tournament { get; set; }
        public int? TournamentID { get; set; }
        public Team? ChallengedGroup { get; set; }
        public int? ChallengedGroupID { get; set; }
        public Team? ChallengedBy { get; set; }
        public int? ChallengedByID { get; set; }
        public GameStatus? GameStatus { get; set; }
        public int? GameStatusID { get; set; }
        public int? WinnerID { get; set; }
        public Group? Winner { get; set; }

    }
}
