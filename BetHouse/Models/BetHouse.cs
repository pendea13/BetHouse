using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetHouseapp.Models
{
    public class BetHouse
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal BalanceRate { get; set; }
        public int TotalBets { get; set; }
        public int NumberOfActiveBets { get; set; }
        public decimal AvailableMoney { get; set; }
        public decimal ValueOfActiveBets { get; set; }
       
    }
}
