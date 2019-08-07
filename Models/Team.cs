using FootballSim.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSim.Models
{
   public class Team
    {
        public string Name { get; set; }
        public List<Player> Players = new List<Player>();
        public List<MatchResult> MatchResults = new List<MatchResult>();

        public override string ToString()
        {
            return Name;
        }

        public Player GetPlayerByPosition(int pos)
        {
            int totalAvailabel= 0;
            while (totalAvailabel == 0 )
            {
                totalAvailabel = Players.Where(p => p.Role.PositionLevel == pos).Count();
            }
            var players = Players.Where(p => p.Role.PositionLevel == pos).ToList();
            return players[TeamInitializer.Rnd.Next(1, totalAvailabel)];
        }
    }
}
