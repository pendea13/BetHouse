using BetHouseapp;
using BetHouseapp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetHouseapp.Controlers
{
    public class BaseControler : MenuHelper
    {
        public BaseControler(User SelectedUser)
        {
            CurrentUser = SelectedUser;
        }

        public User CurrentUser { get; set; }
    }
}
