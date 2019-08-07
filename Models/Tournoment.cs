using FootballSim.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSim.Models
{
    class Tournoment
    {

        public List<Match> Matches { get; set; }

        public Tournoment()
        {
            Matches = new List<Match>();
            TeamInitializer teamInit = new TeamInitializer();

            List<Team> SchaduledTeams = new List<Team>();
            foreach (Team team in teamInit.Teams)
            {
                bool isHome = true;
                foreach (Team opponent in teamInit.Teams)
                {
                    if (opponent.Name != team.Name && !SchaduledTeams.Contains(opponent))
                    {
                        if (isHome)
                        {
                            Matches.Add(new Match() { TeamHome = team, TeamGuest = opponent });
                        }
                        else
                        {
                            Matches.Add(new Match() { TeamHome = opponent, TeamGuest = team });
                        }
                        isHome = !isHome;
                    }
                }
                SchaduledTeams.Add(team);
            }

        }

    }
}
