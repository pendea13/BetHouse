using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetHouseapp.Models
{
   public class Games
    {
        public Guid Id { get; set; }
        public List<Team> Teams { get; set; }
        public GameType GameType { get; set; }
        public bool Ended { get; set; }
        public List<decimal> Odds { get; set; }
    }
    public enum GameType { Soccer, HorseRace, Tenis }
}
