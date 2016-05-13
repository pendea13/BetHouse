using BetHouseapp.Controlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetHouseapp
{
    class Program
    {
        private static void Main(string[] args)
        {
            Data.Data.SeedData();
            SelectControler.Instance.SelectUser();
        }

        private static UserControler _UserControler { get; set; }
        private static AdminControler _AdminControler { get; set; }


    }

}
