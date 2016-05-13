using BetHouseapp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetHouseapp.Controlers
{
    public class UserControler : BaseControler
    {



        public UserControler(User SelectedUser) : base(SelectedUser)
        {
            CurrentUser = SelectedUser;

            ShowUserMenu();
        }
        public void ShowUserMenu()
        {
            UIDecoration.Title($"Hello {CurrentUser.Name}");

            List<string> menu = new List<string>();

            

            clearMenuOptions();

            UIDecoration.Dialog($"Current balance: {CurrentUser.Balance.ToString("C")} ", ConsoleColor.Cyan);
            //UIDecoration.Dialog($"Total Bets:{SettingsService.Settings.TotalBets} Active bets: {SettingsService.Settings.NumberOfActiveBets} Value of active bets: {SettingsService.Settings.ValueOfActiveBets.ToString("c2")}", ConsoleColor.Cyan);

            Console.WriteLine();

            menu.Add("Add Bet");
            menu.Add("Bet History");

            menu.Add("Logout");

            while (!isPharsed)
                isPharsed = UIDecoration.Menu(menu, "Invalid selection, please try again...", 1, 3, out menuSelection);
            switch (menuSelection)
            {
                case 1:
                    BettingService.BettingService.Instance.PlaceBet(CurrentUser,() => ShowUserMenu());
                    break;

                case 2:
                    //UserService.Instance.AddNewUser(false, () => AdminMenu());
                    break;

                case 3:
                    SelectControler.Instance.SelectUser();
                    break;
            }
        }
    }
}
