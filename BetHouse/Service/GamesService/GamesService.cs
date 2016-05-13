using BetHouseapp.Controlers;
using BetHouseapp.Helpers;
using BetHouseapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetHouseapp.Service.GamesService
{
    class GamesService : MenuHelper
    {
        private static GamesService _instance;
        public static GamesService Instance => _instance ?? (_instance = new GamesService());


        public void GameTypeMenu(Action continueWith)
        {
            UIDecoration.Title($"Select Game Type");
            //  UIDecoration.Dialog($"Current balance: {BetHouse.Balance.ToString("C")} Trashhold: {SettingsService.Settings.Treshhold.ToString("P")}", ConsoleColor.Cyan);
            List<string> menu = new List<string>();

            //SettingsService.UpdateSettings();

            clearMenuOptions();



            Console.WriteLine();

            menu.Add("Soccer");
            menu.Add("Tenis");
            menu.Add("Horses");
            menu.Add("Back");

            while (!isPharsed)
                isPharsed = UIDecoration.Menu(menu, "Invalid selection, please try again...", 1, 4, out menuSelection);

            switch (menuSelection)
            {
                case 1:
                    //add game soccer
                    Instance.AddNewSoccerGame(() => GameTypeMenu(continueWith));
                    break;

                case 2:
                    //add game tenis
                    Instance.AddNewTenisGame(() => GameTypeMenu(continueWith));
                    break;
                case 3:
                    //add game horse
                    Instance.AddNewHorseGame(() => GameTypeMenu(continueWith));
                    break;



                case 4:
                    continueWith();

                    break;
            }
        }
        //add soccer game

        public void AddNewSoccerGame(Action continueWith)
        {
            clearMenuOptions();

            UIDecoration.Title("Creating new Soccer Game");

            Games game = new Games();

            game.Teams = new List<Team>();
            game.Odds = new List<decimal>();

            UIDecoration.Dialog("Select first team ");

            Team firstTeam = TeamService.Instance.SelectTeam(continueWith);

            game.Teams.Add(firstTeam);

            clearMenuOptions();

            decimal odds = -1;

            while (!isPharsed)
                isPharsed = UIDecoration.Question($"Set odds for  {firstTeam.Name}:", "Where Wrong", out odds);

            game.Odds.Add(odds);

            UIDecoration.Dialog("Select second team ");

            Team secondTeam = TeamService.Instance.SelectTeam(continueWith);

            game.Teams.Add(secondTeam);

            clearMenuOptions();

            odds = -1;

            while (!isPharsed)
                isPharsed = UIDecoration.Question($"Set odds for  {secondTeam.Name}:", "Where Wrong", out odds);

            game.Odds.Add(odds);

            clearMenuOptions();

            odds = -1;

            while (!isPharsed)
                isPharsed = UIDecoration.Question($"Set odds for draw:", "Where Wrong", out odds);

            game.Odds.Add(odds);

            UIDecoration.Title($"Game : {firstTeam.Name} - {game.Odds[0]} vs {secondTeam.Name} - {game.Odds[1]}  Drow - {game.Odds[2]} has added");

            game.GameType = GameType.Soccer;
            game.Ended = false;
            game.Id = Guid.NewGuid();
            Data.Data.SaveGame(game);
            clearMenuOptions();



            continueWith();
        }

        //Add Tenis game
        public void AddNewTenisGame(Action continueWith)
        {
            clearMenuOptions();

            UIDecoration.Title("Creating new Tenis Game");

            Games game = new Games();

            game.Teams = new List<Team>();
            game.Odds = new List<decimal>();

            UIDecoration.Dialog("Select first team ");

            Team firstTeam = TeamService.Instance.SelectTeam(continueWith);

            game.Teams.Add(firstTeam);

            clearMenuOptions();

            decimal odds = -1;

            while (!isPharsed)
                isPharsed = UIDecoration.Question($"Set odds for  {firstTeam.Name}:", "Where Wrong", out odds);

            game.Odds.Add(odds);

            UIDecoration.Dialog("Select second team ");

            Team secondTeam = TeamService.Instance.SelectTeam(continueWith);

            game.Teams.Add(secondTeam);

            clearMenuOptions();

            odds = -1;

            while (!isPharsed)
                isPharsed = UIDecoration.Question($"Set odds for  {secondTeam.Name}:", "Where Wrong", out odds);

            game.Odds.Add(odds);

            clearMenuOptions();





            UIDecoration.Title($"Game : {firstTeam.Name} - {game.Odds[0]} vs {secondTeam.Name} - {game.Odds[1]}   has added");

            game.GameType = GameType.Tenis;
            game.Ended = false;
            game.Id = Guid.NewGuid();
            Data.Data.SaveGame(game);
            clearMenuOptions();



            continueWith();
        }
        //add Horse game
        public void AddNewHorseGame(Action continueWith)
        {
            clearMenuOptions();

            UIDecoration.Title("Creating new Horse Game");
            int index = 0;
            string horseGame = "Horses:";
            Games game = new Games();

            game.Teams = new List<Team>();
            game.Odds = new List<decimal>();
            int maxTeams = 0;

            UIDecoration.Dialog($"Select number of horses  ");
            while (!isPharsed)
                isPharsed = UIDecoration.Menu(menu, $"Set Number of horses", 1, Data.Data.Teams.Count + 1, out maxTeams);

            while (index < maxTeams)
            {
                index++;
                UIDecoration.Dialog($"Select {index} team ");

                Team firstTeam = TeamService.Instance.SelectTeam(continueWith);

                game.Teams.Add(firstTeam);

                clearMenuOptions();

                decimal odds = -1;

                while (!isPharsed)
                    isPharsed = UIDecoration.Question($"Set odds for  {firstTeam.Name}:", "Where Wrong", out odds);

                game.Odds.Add(odds);
                horseGame += $"Nr.{index} {firstTeam.Name}- {game.Odds[index - 1]} ,";
            }







            UIDecoration.Title($"{horseGame}");

            game.GameType = GameType.HorseRace;
            game.Ended = false;
            game.Id = Guid.NewGuid();
            Data.Data.SaveGame(game);
            clearMenuOptions();



            continueWith();
        }
        //show games by type
        public void ShowGames(Action continueWith)
        {
            int index = 0;
            foreach (Games game in Data.Data.Games)
            {
                if (game.GameType == GameType.Soccer)
                {


                    UIDecoration.Dialog($"Game Type:{game.GameType} : {game.Teams[0].Name} - {game.Odds[0]} vs {game.Teams[1].Name} - {game.Odds[1]}  Drow - {game.Odds[2]}");
                }
                else if (game.GameType == GameType.Tenis)
                {
                    UIDecoration.Dialog($"Game Type:{game.GameType} : {game.Teams[0].Name} - {game.Odds[0]} vs {game.Teams[1].Name} - {game.Odds[1]}  ");
                }
                else
                {
                    string showHorse = " ";
                    while (index < game.Teams.Count)
                    {
                        showHorse += $"Nr.{index+1} {game.Teams[index].Name}- {game.Odds[index]} ,";
                        index++;
                    }
                    UIDecoration.Dialog($"Game Type:{game.GameType} :{showHorse}");
                }
            }

            continueWith();

        }



    }
}