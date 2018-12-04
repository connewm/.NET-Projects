using Newman.RolePlayingGameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Connor Newman -- CSE 4253
 * The purpose of this lab was making an RPG simulator in which a party of "player" characters do a battle simulation
 * with a group of "enemy" characters. This was done implementing an attack system described and implemented using
 * the Combat interface and class respectively as well as a supporting library providing implementations containing data
 * about characters and attacks
 * 
 * ICharacter (and its implementing classes) provided data for several different character classes and their behavior
 * IAttack (and its implementing classes) provided data for various attacks corresponding to the various character classes
 * 
 * Other classes that made this implentation possible were the GameConstants providing default values to be used by IAttack and ICharacter as well as 
 * RNG whcih I made into a singleton (differtent from the in-class implementation) in order to have a unified RNG seed for the entire game.
 * 
 * Once Combat was instantiated with previously instantiated ICharacter objects (in a list) AutoBattle() is called and the battle commences.
 * Player and enemy health is equal currently for balanced play, and each party will win half of the time given large number of trials due to 
 * the RNG
 * */

namespace Newman.RPGCore
{
    class Test
    {
        static void Main(string[] args)
        {
            var playerGroup = new List<ICharacter>();
            var enemyGroup = new List<ICharacter>();


            // characters have default 20 HP a piece for balance
            ICharacter player1 = new Mage("Mirage", 20);
            ICharacter player2 = new Warrior("Rhino", 20);
            ICharacter player3 = new Archer("Banshee", 20);
            ICharacter player4 = new ComputerWizard("Connor", 20);

            ICharacter enemy1 = new Warrior("Nate", 20);
            ICharacter enemy2 = new Mage("Dude", 20);
            ICharacter enemy3 = new Mage("Wizard", 20);
            ICharacter enemy4 = new Warrior("Punchface", 20);

            // add players to groups
            playerGroup.Add(player1);
            playerGroup.Add(player2);
            playerGroup.Add(player3);
            playerGroup.Add(player4);

            enemyGroup.Add(enemy1);
            enemyGroup.Add(enemy2);
            enemyGroup.Add(enemy3);
            enemyGroup.Add(enemy4);

            string playerName = "Good Guys";
            string enemyName = "Simply Misunderstood Guys";

            // create intsance and call autobattle()
            ICombat com = new Combat(playerGroup, enemyGroup, playerName, enemyName);
            com.AutoBattle();
            Console.ReadLine();
        }
    }
}
