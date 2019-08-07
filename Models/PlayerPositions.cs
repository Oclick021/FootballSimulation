using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSim.Models
{
    public class PlayerRole
    {
        //some positions are left out for simplifing the simulation.
        public enum Position { GK, FB, CB, SP, CM, S };

        public Position PlayerPosition { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int PlayMaker { get; set; }
        public int PositionLevel { get; set; }


        public PlayerRole()
        {

        }

        public PlayerRole(Position playerPosition)
        {
            PlayerPosition = playerPosition;

            switch (PlayerPosition)
            {
                case Position.GK:
                    SetPlayerStat(5, 70, 5);
                    PositionLevel = 1;
                    break;
                case Position.FB:

                    SetPlayerStat(10, 60, 60);
                    PositionLevel = 2;

                    break;
                case Position.CB:
                                        SetPlayerStat(20, 65, 20);
                    PositionLevel = 3;

                    break;
                case Position.SP:
                    SetPlayerStat(50, 60, 50);
                    PositionLevel = 4;

                    break;
                case Position.CM:
                    SetPlayerStat(60, 30, 60);
                    PositionLevel = 5;
                    break;
                case Position.S:
                    SetPlayerStat(70, 5, 5);
                    PositionLevel = 6;
                    break;
                default:
                    break;
            }

        }
        

        private void SetPlayerStat(int attackChance, int defenceChance, int playeMakerChance)
        {
            Attack = attackChance;
            Defence = defenceChance;
            PlayMaker = playeMakerChance;
        }
    }
}
