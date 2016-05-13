using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetHouseapp.Helpers
{
    public abstract class MenuHelper
    {
        protected int menuSelection = -1;
        protected bool isPharsed = false;

        protected List<string> menu = new List<string>();

        protected void clearMenuOptions()
        {
            isPharsed = false;
            menuSelection = -1;
            menu = new List<string>();
        }
    }
}
