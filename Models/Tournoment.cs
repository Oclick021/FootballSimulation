using FootballSim.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSim.Models
{
    /// <summary>
    /// This class contains the list of the teams playing in tournoment and their schadules
    /// </summary>
    class Tournoment
    {
        public List<Team> Teams { get; set; }
        public ObservableCollection<Match> Matches { get; set; }

        public Tournoment()
        {
            Matches = new ObservableCollection<Match>();
            Teams =  new TeamInitializer().Teams;
            SchaduleTournoment();
        }


        void SchaduleTournoment()
        {
            List<Team> SchaduledTeams = new List<Team>();
            foreach (Team team in Teams)
            {
                bool isHome = true;
                foreach (Team opponent in Teams)
                {
                    //this foreach makes sure that any team will only play against another team once.
                    if (opponent.Name != team.Name && !SchaduledTeams.Contains(opponent))
                    {
                        if (isHome)
                        {
                            Matches.Add(new Match(team, opponent));
                        }
                        else
                        {
                            Matches.Add(new Match(opponent, team));
                        }
                        isHome = !isHome;
                    }
                }
                SchaduledTeams.Add(team);
            }
        }
    }
}
