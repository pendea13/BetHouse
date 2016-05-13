using BetHouseapp.Data;
using BetHouseapp.Helpers;
using BetHouseapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetHouseapp.Service.GamesService
{
  public  class TeamService:MenuHelper

    {
        private static TeamService _instance;

        public static TeamService Instance => _instance ?? (_instance = new TeamService());
        public void AddNewTeam(Action continueWith)
        {
            UIDecoration.Title("Adding new Team");

            Team team = new Team();
            team.Id = Guid.NewGuid();

            UIDecoration.Dialog("Team's  name?");
            team.Name = Console.ReadLine();

            Data.Data.SaveTeam(team);
            UIDecoration.Title($"Team {team.Name} has been added");
          

            continueWith();
        }
        public void AddUser(Action continueWith)
        {
            UIDecoration.Title("Adding User");

            User user = new User();
            user.Id = Guid.NewGuid();

            UIDecoration.Dialog("User's  name?");
            user.Name = Console.ReadLine();

            user.IsAdmin = false;
            user.Balance = 5000m;

            Data.Data.SaveUser(user);
            UIDecoration.Title($"User {user.Name} has been added");


            continueWith();
        }
        public Team SelectTeam(Action continueWith)
        {
            clearMenuOptions();

            Team t0 = new Team();

            var menu = new List<string>();

            foreach (Team t in Data.Data.Teams) menu.Add(t.Name);

            menu.Add("Back to main menu");

            int backToMain = Data.Data.Teams.Count + 1;

            while (!isPharsed)
                isPharsed = UIDecoration.Menu(menu, "Invalid selection, please try again...", 0, backToMain, out menuSelection);

            if (menuSelection == backToMain)
            {
                continueWith();
            }
            t0 = Data.Data.Teams[menuSelection - 1];

            clearMenuOptions();

            return t0;
        }
    }
}
