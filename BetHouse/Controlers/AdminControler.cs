using BetHouseapp.Controlers;
using BetHouseapp.Helpers;
using BetHouseapp.Models;
using BetHouseapp.Service.GamesService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetHouseapp.Controlers
{
    public class AdminControler : BaseControler


    {
        public AdminControler(User SelectedUser) : base(SelectedUser)
        {
            CurrentUser = SelectedUser;

            ShowAdminMenu();
        }
        public void ShowAdminMenu()
        {
            UIDecoration.Title($"Hello {CurrentUser.Name}");
            //  UIDecoration.Dialog($"Current balance: {BetHouse.Balance.ToString("C")} Trashhold: {SettingsService.Settings.Treshhold.ToString("P")}", ConsoleColor.Cyan);
            List<string> menu = new List<string>();

            //SettingsService.UpdateSettings();

            clearMenuOptions();



            Console.WriteLine();

            menu.Add("Add new team");
            menu.Add("Add new game");
            menu.Add("Add new User");
            menu.Add("Validate game results\\View games");
            menu.Add("Logout");

            while (!isPharsed)
                isPharsed = UIDecoration.Menu(menu, "Invalid selection, please try again...", 1, 6, out menuSelection);

            switch (menuSelection)
            {
                case 1:
                    //add game
                    TeamService.Instance.AddNewTeam(() => ShowAdminMenu());
                    break;

                case 2:
                    //add game
                    GamesService.Instance.GameTypeMenu(() => ShowAdminMenu());
                    break;
                case 3:
                    //add game
                    TeamService.Instance.AddUser(() => ShowAdminMenu());
                    break;

                case 4:
                    //validate game
                    GamesService.Instance.ShowGames(() => ShowAdminMenu());
                    break;

                case 5:
                    SelectControler.Instance.SelectUser();
                    break;
            }
        }

    }
}