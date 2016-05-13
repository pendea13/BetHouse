using BetHouseapp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetHouseapp.Controlers
{
   public class SelectControler:MenuHelper

    {
        private static AdminControler _adminControler { get; set; }
        private static UserControler _userControler { get; set; }
        private static SelectControler _instance;
        public static SelectControler Instance => _instance ?? (_instance = new SelectControler());
        public void SelectUser()
        {
            clearMenuOptions();
            User SelectedUser;
            UIDecoration.Title($"Welcome at Bet House! ");
            UIDecoration.Title($"Select User:");
                foreach (User acc in Data.Data.Users)
                {
                    menu.Add(acc.Name);
                }

                while (!isPharsed)
                    isPharsed = UIDecoration.Menu(menu, "Wrong!", 1, Data.Data.Users.Count + 1 , out menuSelection);
            SelectedUser = Data.Data.Users[menuSelection -1];
            if (!SelectedUser.IsAdmin)
            {
                _userControler = new UserControler(SelectedUser);
            }
            else
            {
                _adminControler = new AdminControler(SelectedUser);  
            }

               
            
        }
    }
}
