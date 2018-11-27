using Newman.RolePlayingGameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newman.RPGCore
{
    class SwordAttack : NormalAttack
    {
        // temporarily we will simply use the algforithim for the Normal Attack for each special
        // we could implement special behavior for each individual attack type
        public override void Attack(ICharacter attacker, ICharacter target)
        {
            // for the simulation write the results of each attack to the console
            Console.WriteLine("{0} swings his sword at {1}!", attacker.Name, target.Name);
            // calls superclass implementation of Attack(...)
            base.Attack(attacker, target);
        }
    }
}
