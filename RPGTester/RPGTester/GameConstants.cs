using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newman.RPGCore
{
    class GameConstants
    {
        // this class must be a singleton so the dodgeDifficulty and other game constants are consistent for all players

        // Various constants
        private const int dodgeDifficulty = 5; // chance is 1/dodgeDifficulty, so higher numbers are harder
        
        // dodgeDifficulty getter
        public int DodgeDifficulty
        {
            get { return dodgeDifficulty; }
        }

        // The damage bonus which is a default baseline damage (5)
        private const int damageBonus = 5;
        // getter for damageBonus
        public int DamageBonus
        {
            get { return damageBonus; }
        }

        // The bonus for "damage range"  which defaults to 10
        private const int damageRange = 10;
        public int DamageRange
        {
            get { return damageRange; }
        }

        //default player hitpoints
        private const int defaultHP = 50;
        public int DefaultHP
        {
            get { return defaultHP; }
        }

        // singular instance variable for singleton class
        private static GameConstants instance = new GameConstants();
        // instance getter
        public static GameConstants Instance
        {
            get { return instance; }
        }

        // default constructor -- private for singleton
        private GameConstants()
        {

        }


    }
}
