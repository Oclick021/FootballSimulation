using FootballSim.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSim.Models
{
    public class Player
    {
        public enum Position { GK, FB, CB, SP, CM, S };



        public string Name { get; set; }

        public int Agility { get; set; } //Affect the Dribble, Pass and Defending
        public int Stamina { get; set; } //Affect the Dribble and Defending
        public int Percision { get; set; } //Affect the  Defending and Shoot
        public int Attack { get; set; } //Affects The Dribble and Shoot
        public int Defence { get; set; } //Affects Defending
        public int PlayMaker { get; set; } //Affects Dribble and Pass

        public bool IsInPossesion { get; set; }
        public bool IsDefending { get; set; }


        public int PositionLevel { get; set; }
        public Position PlayerPosition { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public Player(string name, Position playerPosition)
        {
            Name = name;
            PlayerPosition = playerPosition;
            SetStats();
        }
        void SetStats()
        {
            ///Now in this case i tried to give a almost balanced numbers to the players so
            ///we can have a little bit more realistic competition
            ///Players in front have more agility attack and precision 
            ///players in middle and side have more Playermaker Stamina and percision
            ///player in back have more stamina defence and percision
            switch (PlayerPosition)
            {
                case Position.GK:
                    Agility = Randomizer.Rnd.Next(20, 80);
                    Stamina = Randomizer.Rnd.Next(20, 60);
                    Percision = Randomizer.Rnd.Next(70, 100);
                    Attack = Randomizer.Rnd.Next(0, 30);
                    Defence = Randomizer.Rnd.Next(50, 100);
                    PlayMaker = Randomizer.Rnd.Next(40, 80);
                    PositionLevel = 1;
                    break;
                case Position.FB:
                    Agility = Randomizer.Rnd.Next(40, 80);
                    Stamina = Randomizer.Rnd.Next(30, 70);
                    Percision = Randomizer.Rnd.Next(40, 100);
                    Attack = Randomizer.Rnd.Next(20, 60);
                    Defence = Randomizer.Rnd.Next(40, 100);
                    PlayMaker = Randomizer.Rnd.Next(40, 70);
                    PositionLevel = 2;

                    break;
                case Position.CB:
                    PositionLevel = 3;

                    Agility = Randomizer.Rnd.Next(30, 70);
                    Stamina = Randomizer.Rnd.Next(50, 100);
                    Percision = Randomizer.Rnd.Next(40, 100);
                    Attack = Randomizer.Rnd.Next(25, 65);
                    Defence = Randomizer.Rnd.Next(40, 75);
                    PlayMaker = Randomizer.Rnd.Next(45, 75);

                    break;
                case Position.SP:
                    PositionLevel = 4;

                    Agility = Randomizer.Rnd.Next(50, 80);
                    Stamina = Randomizer.Rnd.Next(50, 80);
                    Percision = Randomizer.Rnd.Next(40, 90);
                    Attack = Randomizer.Rnd.Next(50, 70);
                    Defence = Randomizer.Rnd.Next(50, 70);
                    PlayMaker = Randomizer.Rnd.Next(60, 100);
                    break;
                case Position.CM:
                    PositionLevel = 5;

                    Agility = Randomizer.Rnd.Next(50, 100);
                    Stamina = Randomizer.Rnd.Next(50, 80);
                    Percision = Randomizer.Rnd.Next(50, 90);
                    Attack = Randomizer.Rnd.Next(50, 85);
                    Defence = Randomizer.Rnd.Next(30, 60);
                    PlayMaker = Randomizer.Rnd.Next(50, 80);
                    break;
                case Position.S:
                    PositionLevel = 6;

                    Agility = Randomizer.Rnd.Next(40, 80);
                    Stamina = Randomizer.Rnd.Next(30, 80);
                    Percision = Randomizer.Rnd.Next(50, 90);
                    Attack = Randomizer.Rnd.Next(50, 100);
                    Defence = Randomizer.Rnd.Next(0, 40);
                    PlayMaker = Randomizer.Rnd.Next(20, 70);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Returns the success rate of a dribble
        /// </summary>
        public double Dribble()
        {
            List<decimal> factors = new List<decimal>(){(decimal)Agility,
                (decimal)Stamina,
                PlayMaker,
                Attack
            };
            factors.Add(Randomizer.Rnd.Next((int)factors.Min(), (int)factors.Max()));
            return GetAverage(factors);
        }
        /// <summary>
        /// Returns the success rate of a pass
        /// </summary>
        public double Pass()
        {
            List<decimal> factors = new List<decimal>(){(decimal)Agility,
                (decimal)Percision,
                (decimal)PlayMaker
            };
            if (PlayerPosition == Position.GK)
            {
                //Extra Positive point is added to goalkeeper because he can pass the ball with hand and foot and 
                //meanwhile attacker cant press him
                factors.Add(100);  
            }
            else
            {
                factors.Add(Randomizer.Rnd.Next((int)factors.Min(), (int)factors.Max()));
            }
            return GetAverage(factors);
        }
        /// <summary>
        /// Returns the success rate of a pass
        /// </summary>
        public double Defend()
        {
            List<decimal> factors = new List<decimal>(){(decimal)Agility,
                (decimal)Stamina,
                Defence
            };
            factors.Add(Randomizer.Rnd.Next((int)factors.Min(), (int)factors.Max()));

            return GetAverage(factors);
        }
        /// <summary>
        /// Returns success rate of a shoot. Later on it will be compensated by Position of the opponent
        /// to Prevent the meaningless shoots. 
        /// </summary>
        public double Shoot()
        {
            List<decimal> factors = new List<decimal>(){(decimal)Percision,
                Attack
            };
            factors.Add(Randomizer.Rnd.Next((int)factors.Min(), (int)factors.Max()));
            return GetAverage(factors);
        }

        double GetAverage(List<decimal> factors)
        {
            return (double)factors.Sum() / factors.Count;
        }
    }
}
