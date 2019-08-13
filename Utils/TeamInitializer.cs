using FootballSim.Models;
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
    /// <summary>
    /// This class will make a semi random list of teams.
    /// </summary>
    class TeamInitializer
    {
        public List<Team> Teams { get; set; }


        public TeamInitializer()
        {
            Teams = new List<Team>();
            Teams.Add(GetTeam("Barca FC"));
            BoostTeam(Teams[0], 10);
            Teams.Add(GetTeam("Real Madrid"));
            BoostTeam(Teams[1], 15);
            Teams.Add(GetTeam("Liverpool"));
            BoostTeam(Teams[0], 5);
            Teams.Add(GetTeam("Juventus"));
        }
        
        /// <summary>
        /// Returns a Team of players
        /// </summary>
        /// <param name="name">Name of the team</param>
        /// <returns></returns>
        Team GetTeam(string name)
        {
            Team team = new Team() { Name = name };
            team.Players.Add(new Player($"GoalKeeper ({team.Name})", Player.Position.GK));
            for (int i = 0; i < 2; i++)
            {
                team.Players.Add(new Player($"FB {i} ({team.Name})", Player.Position.FB));
            }
            for (int i = 0; i < 3; i++)
            {
                team.Players.Add(new Player($"CB {i} ({team.Name})", Player.Position.CB));
            }
            team.Players.Add(new Player($"SP ({team.Name})", Player.Position.SP));
            for (int i = 0; i < 2; i++)
            {
                team.Players.Add(new Player($"CM {i} ({team.Name})", Player.Position.CM));
            }
            for (int i = 0; i < 2; i++)
            {
                team.Players.Add(new Player($"S {i} ({team.Name})", Player.Position.S));
            }
            return team;
        }

        /// <summary>
        /// Boosts a selected team with a selected amount of ability
        /// </summary>
        /// <param name="t">Team you want to boost</param>
        /// <param name="boost">Amount of boost you want to give the players of the team</param>
        void BoostTeam(Team t, int boost)
        {
            foreach (var player in t.Players)
            {
                player.Agility += boost;
                player.Attack += boost;
                player.Defence += boost;
                player.Percision += boost;
                player.PlayMaker += boost;
                player.Stamina += boost;
            }
        }


    }
}
