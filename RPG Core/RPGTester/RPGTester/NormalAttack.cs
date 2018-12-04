using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newman.RolePlayingGameInterfaces;

namespace Newman.RPGCore
{
    // sets general properties for attacks. Each class has an attack which will inherit from this and override the default behavior
    // think of them as special attacks
    // sets basic 
    class NormalAttack : IAttack
    {
        

        // will need overriden by every character class class
        public virtual void Attack(ICharacter attacker, ICharacter target)
        {
            // bear in mind damagebonus is always 5 and damagerange is wrapped in an RNG so it is 1-10
            int damage = GameConstants.Instance.DamageBonus + RNG.Instance.RandomNumbers.Next(GameConstants.Instance.DamageRange);
            target.ReceiveAttack(damage);
        }
    }
}
