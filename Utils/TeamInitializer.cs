using FootballSim.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FootballSim.Utils
{
    class TeamInitializer
    {
        public static Random Rnd = new Random();
        public List<Team> Teams { get; set; }


        public TeamInitializer()
        {
            Teams = new List<Team>();
            Teams.Add(GetTeam("Barca FC"));
            Teams.Add(GetTeam("Real Madrid"));
            Teams.Add(GetTeam("Liverpool"));
             SetTeamStroid();
        }
        Team GetTeam(string name)
        {
            Team team = new Team() { Name = name };
            team.Players.Add(new Player("GoalKeeper", Rnd.Next(1, 88), Rnd.Next(18, 35), Rnd.Next(40, 100), Rnd.Next(40, 100), Rnd.Next(40, 100), new PlayerRole(PlayerRole.Position.GK)));
            for (int i = 0; i < 2; i++)
            {
                team.Players.Add(new Player($"FB {i}", Rnd.Next(1, 88), Rnd.Next(18, 35), Rnd.Next(40, 100), Rnd.Next(40, 100), Rnd.Next(40, 100), new PlayerRole(PlayerRole.Position.FB)));
            }
            for (int i = 0; i < 3; i++)
            {
                team.Players.Add(new Player($"CB {i}", Rnd.Next(1, 88), Rnd.Next(18, 35), Rnd.Next(40, 100), Rnd.Next(40, 100), Rnd.Next(40, 100), new PlayerRole(PlayerRole.Position.CB)));
            }
            for (int i = 0; i < 3; i++)
            {
                team.Players.Add(new Player($"CM {i}", Rnd.Next(1, 88), Rnd.Next(18, 35), Rnd.Next(40, 100), Rnd.Next(40, 100), Rnd.Next(40, 100), new PlayerRole(PlayerRole.Position.CM)));
            }
            for (int i = 0; i < 2; i++)
            {
                team.Players.Add(new Player($"S {i}", Rnd.Next(1, 88), Rnd.Next(18, 35), Rnd.Next(40, 100), Rnd.Next(40, 100), Rnd.Next(40, 100), new PlayerRole(PlayerRole.Position.S)));
            }
            return team;
        }
        void SetTeamStroid()
        {
            Team team = new Team() { Name = "On Stroid" };

            team.Players.Add(new Player("GoalKeeper", Rnd.Next(1, 88), Rnd.Next(21, 28), Rnd.Next(70, 100), Rnd.Next(70, 100), Rnd.Next(70, 100), new PlayerRole(PlayerRole.Position.GK)));
            for (int i = 0; i < 2; i++)
            {
                team.Players.Add(new Player($"FB {i}", Rnd.Next(1, 88), Rnd.Next(21, 28), Rnd.Next(70, 100), Rnd.Next(70, 100), Rnd.Next(70, 100), new PlayerRole(PlayerRole.Position.FB)));
            }
            for (int i = 0; i < 3; i++)
            {
                team.Players.Add(new Player($"CB {i}", Rnd.Next(1, 88), Rnd.Next(21, 28), Rnd.Next(70, 100), Rnd.Next(70, 100), Rnd.Next(70, 100), new PlayerRole(PlayerRole.Position.CB)));
            }
            for (int i = 0; i < 3; i++)
            {
                team.Players.Add(new Player($"CM  {i}", Rnd.Next(1, 88), Rnd.Next(21, 28), Rnd.Next(70, 100), Rnd.Next(70, 100), Rnd.Next(70, 100), new PlayerRole(PlayerRole.Position.CB)));
            }
            for (int i = 0; i < 2; i++)
            {
                team.Players.Add(new Player($"S {i}", Rnd.Next(1, 88), Rnd.Next(21, 28), Rnd.Next(70, 100), Rnd.Next(70, 100), Rnd.Next(70, 100), new PlayerRole(PlayerRole.Position.S)));
            }
            Teams.Add(team);
        }

    }
}
