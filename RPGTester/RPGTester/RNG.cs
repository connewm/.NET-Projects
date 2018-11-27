using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newman.RPGCore
{
    // a singleton that allows the whole game to use the same seed for the RNG
    class RNG
    {
        private Random randomNumbers = new Random();
        public Random RandomNumbers
        {
            get { return randomNumbers; }
        }

        private static RNG instance = new RNG();
        public static RNG Instance
        {
            get { return instance; }
        }

        // default private constructor
        private RNG()
        {

        }
    }
}
