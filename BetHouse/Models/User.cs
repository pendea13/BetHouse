using BetHouseapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetHouseapp
{
   public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
      
        public decimal Balance { get; set; }
        private List<Bet> BetHistory { get; set; }
        public bool IsAdmin { get; set; }
    }
}
