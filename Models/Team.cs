using FootballSim.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSim.Models
{
    public class Team
    {
        public string Name { get; set; }
        public ObservableCollection<Player> Players { get; set; }
        public bool IsInPossesion { get; set; }

        public int Score { get; set; }
        public int Recieved { get; set; }

        public TeamResults Results { get; set; }
        public Team()
        {
            Players = new ObservableCollection<Player>();
            Results = new TeamResults();
        }
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// In case this team has a player in possession and in attacking situation then the player will be return 
        /// </summary>
        /// <returns>Player Object / Null</returns>
        public Player ReturnAttackinglayer()
        {
            return Players.Where(p => p.IsInPossesion).FirstOrDefault();
        }
        /// <summary>
        /// In case this team has a player in defending and against the opponent attacker  then the player will be return 
        /// </summary>
        /// <returns>Player Object / Null</returns>
        public Player ReturnPlayerDefending()
        {
            return Players.Where(p => p.IsDefending).FirstOrDefault();
        }
        /// <summary>
        /// Returns the Attacking or Defending player of the team.
        /// </summary>
        /// <returns>Player Object / Null</returns>
        public Player ReturnActivePlayer()
        {
            if (ReturnAttackinglayer() is Player p)
            {
                return p;
            }
            return ReturnPlayerDefending();
        }

        /// <summary>
        /// Returns a player based on its position
        /// </summary>
        /// <param name="pos">Position of the player</param>
        /// <param name="excludeName">Exclude a player based on its name </param>
        /// <returns>Player Object / Null</returns>
        public Player ReturnByPosition(int pos, string excludeName = "")
        {
            if (pos > 6)
            {
                pos = 6;
            }
            var res = Players.Where(p => p.PositionLevel == pos && p.Name != excludeName).OrderBy(x => Randomizer.Rnd.Next()).Take(1).FirstOrDefault();
            return res;
        }

        /// <summary>
        /// Clean the team of having a player in defening or attacking mode.
        /// Will be used in restarting and kickof
        /// </summary>
        public void Clear()
        {
            foreach (Player p in Players)
            {
                p.IsDefending = false;
                p.IsInPossesion = false;
            }
        }


     
    }
}
