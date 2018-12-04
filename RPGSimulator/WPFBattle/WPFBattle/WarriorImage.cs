using Newman.RPGCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBattle
{
    class WarriorImage : Warrior
    {
        private CharacterImage currentImage;

        public WarriorImage(CharacterImage image, string name, int health)
        {
            this.currentImage = image;
            this.Health = health;
            this.Name = name;
            this.CharacterClass = "Warrior";
            this.attackBehavior = new SwordAttackImage(image);
        }

        public override void ReceiveAttack(int damage)
        {
            // set to 'hurt'/'defending' state for 3 seconds
            this.currentImage.State = CharacterImage.CharacterState.Defending;
            System.Threading.Thread.Sleep(3000);

            // resolve the attack
            base.ReceiveAttack(damage);

            // if health = 0, show dead image. Otherwise return to idle state
            if (this.Health == 0)
            {
                this.currentImage.State = CharacterImage.CharacterState.Dead;
            } else
            {
                this.currentImage.State = CharacterImage.CharacterState.Idle;
            }
        }
    }
}
