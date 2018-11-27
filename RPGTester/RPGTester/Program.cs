using Newman.RolePlayingGameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newman.RPGCore
{
    class Program
    {
        private IList<ICharacter> playerParty = new List<ICharacter>();

        static void Main(string[] args)
        {
            ICharacter player1 = new Mage("Mirage");
            ICharacter player2 = new Warrior("Rhino");

            Console.WriteLine(player1);
            Console.WriteLine(player2);

            player1.PerformAttack(player2);

            Console.WriteLine(player1);
            Console.WriteLine(player2);

            player2.PerformAttack(player1);

            Console.WriteLine(player1);
            Console.WriteLine(player2);

            Console.ReadLine();
        }
    }
}
