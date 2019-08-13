using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSim.Utils
{
    /// <summary>
    /// This reason i made a randomizer with a static Random Object is to prevent to get a repetitive randomized number. 
    /// </summary>
    public class Randomizer
    {
        public static Random Rnd = new Random();
    }
}
