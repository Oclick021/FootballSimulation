using FootballSim.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSim.Models
{
    public class Match
    {
        public Team TeamHome { get; set; }
        public Team TeamGuest { get; set; }
        public string Result { get; set; }

        public bool MatchPlayed { get; set; }

        public string Output;
        public int MatchTime = 90;
        MatchResult MatchResut = new MatchResult();

        private Player ActivePlayer;
        private Player ActiveOponnent;
        int opponnentPos;
        bool IsHomeInControl;
        public Match()
        {

        }
        public void StartMatch()
        {
            ActivePlayer = TeamGuest.GetPlayerByPosition(6);
            IsHomeInControl = true;
            GetOponnentPlayer();
        }
        public void Cycle()
        {
            MatchTime -= 5;
            Action();
        }
        void GetOponnentPlayer()
        {
            if (ActiveOponnent == null)
            {
                opponnentPos = 6;
                ActiveOponnent = TeamGuest.GetPlayerByPosition(opponnentPos);
            }
            else if (IsHomeInControl)
            {
                ActiveOponnent = TeamGuest.GetPlayerByPosition(opponnentPos);
            }
            else
            {
                ActiveOponnent = TeamHome.GetPlayerByPosition(opponnentPos);
            }

        }
        public void Action()
        {
            opponnentPos = ActiveOponnent.Role.PositionLevel;
            int dribbleChance = ActivePlayer.Dribble();
            int passChance = ActivePlayer.Pass();
            int defendChance = ActiveOponnent.Defend();
            int shootChance = ActivePlayer.Shoot();
            if ((shootChance / opponnentPos) > defendChance)
            {
                Score();
            }
            else if (dribbleChance > defendChance)
            {
                opponnentPos--;
                GetOponnentPlayer();
            }
            else if (passChance > defendChance)
            {
                Pass();
            }
            else
            {
                IsHomeInControl = !IsHomeInControl;
                opponnentPos = ActivePlayer.Role.PositionLevel;
                ActivePlayer = ActiveOponnent;
                GetOponnentPlayer();
            }

        }
        void Pass()
        {

        }
        void Score()
        {

        }
    }
}
