using Newman.RolePlayingGameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newman.RPGCore
{
    class FireAttack : NormalAttack
    {
        public override void Attack (ICharacter attacker, ICharacter target)
        {
            // different console.writeline for fire attack
            Console.WriteLine("{0} used a fire attack against {1}!", attacker.Name, target.Name);
            // call superclass implementation
            base.Attack(attacker, target);
        }
    }
}
