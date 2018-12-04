using Newman.RolePlayingGameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newman.RPGCore
{
    class BowAttack : NormalAttack
    {
        // same implementation as other specific attacks
        public override void Attack(ICharacter attacker, ICharacter target)
        {
            Console.WriteLine("{0} launches an arrow at {1}!", attacker.Name, target.Name);
            base.Attack(attacker, target);
        }
    }
}
