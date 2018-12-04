using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newman.RolePlayingGameInterfaces;



// used for determining the basic functions of characters in the following game
namespace Newman.RPGCore
{
    class CharacterBase : ICharacter
    {
        protected const string AnonymousName = "Anonymous";
        protected static int anonymousCounter = 0;
        protected IAttack attackBehavior;
         

        public string CharacterClass
        {
            get;
            protected set;
        }

        public string Name
        {
            get;
            protected set;
        }

        public int Health
        {
            get;
            protected set;
        }

        public void PerformAttack(ICharacter target)
        {
            attackBehavior.Attack(this, target);
        }

        public void ReceiveAttack(int damage)
        {
            if (RNG.Instance.RandomNumbers.Next(GameConstants.Instance.DodgeDifficulty) != 0)
            {
                Console.WriteLine(this.Name + " takes " + damage + " damage");
                this.Health -= damage;
                if (this.Health < 0) this.Health = 0;
            } else
            {
                Console.WriteLine(this.Name + " dodged the attack");
            }
        }

        // override which allows the game to output a given characters name, class, and health
        public override string ToString()
        {
            return String.Format("{0} the {1} has {2} health.", Name, CharacterClass, Health);
        }
    }
}
