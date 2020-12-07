using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickerAPI.Models
{
    public class Competition
    {
        public int CompetitionID { get; set; }
        public string Name { get; set; }
        
        //Relations
        public GameType GameType { get; set; }
        public int GameTypeID { get; set; }
        public Group Winner { get; set; }
        public int WinnerID { get; set; }
    }
}
