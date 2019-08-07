using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSim.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int Age { get; set; }
        public double Agility { get; set; }
        public double Stamina { get; set; }
        public double Percision { get; set; }
        public bool IsInjured { get; set; }
        public PlayerRole Role { get; set; }


        public Player(string name, int number, int age, double agility, double stamina, double percision, PlayerRole role)
        {
            Name = name;
            Number = number;
            Age = age;
            Agility = agility;
            Stamina = stamina;
            Percision = percision;
            Role = role;
        }

      public  int Dribble()
        {
            return 0;

        }
        public int Pass()
        {
            return 0;
        }
        public int Defend()
        {
            return 0;
        }
        public int Shoot()
        {
            return 0;
        }
    }
}
