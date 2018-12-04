using Newman.RolePlayingGameInterfaces;
using Newman.RPGCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBattle
{
    class DualWielderAttackImage : NormalAttack
    {
        private CharacterImage currentImage;
        //constructor creating SwordAttack with image
        public DualWielderAttackImage(CharacterImage image)
        {
            this.currentImage = image;
        }
        public override void Attack(ICharacter attacker, ICharacter target)
        {
            // write line as in normal warrior attack
            Console.WriteLine("{0} swings both of his swords at {1}!", attacker.Name, target.Name);
            // set character state to attacking
            currentImage.State = CharacterImage.CharacterState.Attacking;
            // finish default behavior
            base.Attack(attacker, target);
            System.Threading.Thread.Sleep(3000);

            currentImage.State = CharacterImage.CharacterState.Idle;
        }
    }
}
