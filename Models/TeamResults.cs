using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSim.Models
{
    public class TeamResults
    {
        private int dif;


        public int MatchPlayed { get; set; }
        public int Win { get; set; }
        public int Loss { get; set; }
        public int Draws { get; set; }
        public int TotalScore { get; set; }
        public int TotalRecieve { get; set; }
        public int Dif { get { return TotalScore-TotalRecieve ; } set => dif = value; }
        public int TotalPoints { get; set; }

        /// <summary>
        /// Result of the latest match will be added to this class to be shown in the result DataGrid
        /// </summary>
        public void AddResult(int score, int recieve)
        {
            MatchPlayed++;
            if (score > recieve)
            {
                Win++;
                TotalPoints += 3;
            }
            else if (score == recieve)
            {
                Draws++;
                TotalPoints++;
            }
            else
            {
                Loss++;
            }
            TotalScore += score;
            TotalRecieve += recieve;
        }
    }
}
