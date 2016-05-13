using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetHouseapp.Models
{
   public class Bet
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public Games Game { get; set; }
        public Team Team { get; set; }
        public DateTime Submited { get; set; }
        public BetType BetType { get; set; }
        public bool IsWinner { get; set; }
        public decimal Odd { get; set; }
        public decimal PotentialWinning { get; set; }
        public bool IsActiv { get; set; }

    }
    public enum BetType { OneTwo , OneXTwo , HorseRace }
}
