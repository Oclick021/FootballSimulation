using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSim.Models
{
    public class MatchResult
    {
        public Team Oponnent { get; set; }
        public int GoalScored { get; set; }
        public int GoalRecieved { get; set; }

    }
}
