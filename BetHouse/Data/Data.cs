using BetHouseapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetHouseapp.Data
{
    public static partial class Data
    {

        public static List<User> Users { get; set; }
        public static List<Bet> Bets { get; set; }
        public static List<Games> Games { get; set; }
        public static List<Team> Teams { get; set; }
        public static void SeedData()
        {
            //if (Users.)
            //{
            //    LoadAllData();
            //}else
            //{
                InitUsers();
                InitTeams();
                InitGames();
                InitBets();
                InitSettings();
          //  }
        }
        public static void LoadAllData()
        {
            Users = XmlSerialization.ReadFromXmlFile<List<User>>("C:\\Data\\user.txt");
            Bets = XmlSerialization.ReadFromXmlFile<List<Bet>>("C:\\Data\\bets.txt");
            Games = XmlSerialization.ReadFromXmlFile<List<Games>>("C:\\Data\\games.txt");
            Teams = XmlSerialization.ReadFromXmlFile<List<Team>>("C:\\Data\\user.txt");
        }
        public static void SaveGame(Games game)
        {

           Games.Add(game);
            XmlSerialization.WriteToXmlFile<List<Games>>("C:\\Data\\games.txt", Games);
        }
        public static void SaveUser(User user)
        {

            Users.Add(user);
            XmlSerialization.WriteToXmlFile<List<User>>("C:\\Data\\user.txt", Users);
        }
        public static void SaveTeam( Team team)
        {
            
            Teams.Add(team);
            XmlSerialization.WriteToXmlFile<List<Team>>("C:\\Data\\team.txt", Teams);
        }
        public static void SaveBet(Bet bets)
        {

            Bets.Add(bets);
            XmlSerialization.WriteToXmlFile<List<Bet>>("C:\\Data\\bets.txt", Bets);
        }

        private static void InitUsers()
        {
            if (Users == null)
                Users = new List<User>();


            User user = new User() { Name = "Admin", Id = Guid.NewGuid(), IsAdmin = true };
            Users.Add(user);
            user = new User() { Name = "John", Id = Guid.NewGuid(), Balance = 5000m , IsAdmin =false };
            Users.Add(user);
            user = new User() { Name = "Raul", Id = Guid.NewGuid(), Balance = 5000m, IsAdmin = false };
            Users.Add(user);
            user = new User() { Name = "Paul", Id = Guid.NewGuid(), Balance = 5000m, IsAdmin = false };
            Users.Add(user);
            user = new User() { Name = "Saul", Id = Guid.NewGuid(), Balance = 5000m, IsAdmin = false };
            Users.Add(user);
            user = new User() { Name = "Baul", Id = Guid.NewGuid(), Balance = 5000m, IsAdmin = false };
            Users.Add(user);
            SaveUser(user);
        }

        private static void InitTeams()
        {
            if (Teams == null)
                Teams = new List<Team>();

            Team team = new Team() { Name = "RedMonkey", Id = Guid.NewGuid() };
            Teams.Add(team);
         
            team = new Team() { Name = "Fly Wyzi", Id = Guid.NewGuid() };
            Teams.Add(team);
           
            team = new Team() { Name = "Sweet Dream", Id = Guid.NewGuid() };
            Teams.Add(team);
  
            team = new Team() { Name = "Bob Billy", Id = Guid.NewGuid() };
            Teams.Add(team);
            SaveTeam(team);

        }

        private static void InitGames()
        {
            if (Games == null)
                Games = new List<Games>();


        }

        private static void InitBets()
        {
            if (Bets == null)
                Bets = new List<Bet>();


        }

        private static void InitSettings()
        {
            BetHouse house = new BetHouse();

            house.Name = "Bet House";
            house.BalanceRate = 0.45m;
            house.Balance = 4555m;
            XmlSerialization.WriteToXmlFile<BetHouse>("C:\\Data\\BetHouse.txt", house);


        }
        public static BetHouse UpdateAvailableMoney(BetHouse updateInfo)
        {

            updateInfo.TotalBets = Bets.Count;
            updateInfo.NumberOfActiveBets = Bets.Where(x => x.IsActiv == false).Count();
            updateInfo.ValueOfActiveBets = Bets.Where(x => x.IsActiv == false).Sum(x => x.Amount);

            updateInfo.AvailableMoney = updateInfo.Balance * updateInfo.BalanceRate - updateInfo.ValueOfActiveBets;



            return updateInfo;
        }
        public static List<Games> GetActivGames()
        {
            List<Games> games = new List<Games>();

            games = Games.Where(x => x.Ended == false).ToList();

            return games;
        }
    }
}

