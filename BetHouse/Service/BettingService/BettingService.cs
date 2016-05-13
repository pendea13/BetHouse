using BetHouseapp.Helpers;
using BetHouseapp.Models;
using BetHouseapp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetHouseapp.BettingService
{
    
    class BettingService:MenuHelper


    {
        private static BettingService _instance;

        public static BettingService Instance => _instance ?? (_instance = new BettingService());


        public void PlaceBet(User user, Action continueWith)

        {
            clearMenuOptions();
            List<Games> activGames = Data.Data.GetActivGames();
            if (activGames.Count == 0)
            {
                UIDecoration.Dialog("There are no games");
                Console.ReadKey();
                continueWith();
            }
            else
            {
                List<string> menu = new List<string>();

                foreach (Games game in activGames)
                {
                    int index = 0;
                    if (game.GameType == GameType.Soccer)
                    {


                        menu.Add($"Game Type:{game.GameType} Teams:{game.Teams[0].Name}-{game.Odds[0].ToString("0.00")} vs {game.Teams[1].Name}-{game.Odds[1].ToString("0.00")} Drow-{game.Odds[2].ToString("0.00")}");
                    }
                    else if (game.GameType == GameType.Tenis)
                    {
                        menu.Add($"Game Type:{game.GameType} : {game.Teams[0].Name} - {game.Odds[0].ToString("0.00")} vs {game.Teams[1].Name} - {game.Odds[1].ToString("0.00")}  ");
                    }
                    else
                    {
                        string showHorse = " ";
                        while (index < game.Teams.Count)
                        {
                            showHorse += $"Nr.{index + 1} {game.Teams[index].Name}- {game.Odds[index].ToString("0.00")} ,";
                            index++;
                        }
                        menu.Add($"Game Type:{game.GameType} :{showHorse}");
                    }
                }

                while (!isPharsed)
                    isPharsed = UIDecoration.Menu(menu, "Wrong value", 1, activGames.Count + 1, out menuSelection);

                Bet bet = new Bet();

                bet.Id = Guid.NewGuid();
                bet.UserId = user.Id;

                bet.Game = activGames[menuSelection - 1];
                bet.Game.Ended = true;
                bet.Submited = DateTime.Now;
                clearMenuOptions();

                menu = new List<string>();
                int selection = bet.Game.Teams.Count;
                foreach (Team t in bet.Game.Teams)
                {
                    menu.Add($"{t.Name}");
                }
                if (bet.Game.GameType == GameType.Soccer)
                {
                    menu.Add("Draw");

                  selection = bet.Game.Teams.Count + 1;
                }
                while (!isPharsed)
                    isPharsed = UIDecoration.Menu(menu, "Wrong value", 0, selection, out menuSelection);

                if (menuSelection == selection)
                    bet.Team = null;
                else
                {
                    bet.Team = bet.Game.Teams[menuSelection - 1];
                }

                decimal amount = 0;

                int oddsIndex = menuSelection - 1;

                bet.Odd = bet.Game.Odds[oddsIndex];

                clearMenuOptions();

                while (!isPharsed)
                    isPharsed = UIDecoration.Question("Amount", "Wrong value", out amount);

                bet.PotentialWinning = bet.Odd * bet.Amount;

                if (amount > user.Balance)
                {
                    UIDecoration.Error($"You don`t have the money!");
                    PlaceBet(user, continueWith);
                }
                Data.Data.SaveBet(bet);
                  continueWith();
                }
            }
        }
    }

