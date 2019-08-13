using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSim.Models
{
    public class MatchLog
    {
        public string Action { get; set; }
        public int MinuteLeft { get; set; }
        public Player PlayerHome { get; set; }
        public Player PlayerGuest { get; set; }
        public bool HomeHasBall { get; set; }

        public MatchLog(string action, int minuteLeft, Player playerHome, Player playerGuest, bool homeHasBall)
        {
            Action = action;
            MinuteLeft = minuteLeft;
            PlayerHome = playerHome;
            PlayerGuest = playerGuest;
            HomeHasBall = homeHasBall;
        }

        public override string ToString()
        {
            return $"{PlayerHome} || {Action} || {PlayerGuest} || {MinuteLeft}m left";
        }
    }
}
