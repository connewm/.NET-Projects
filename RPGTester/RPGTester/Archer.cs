using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newman.RPGCore
{
    // character class for archer with similar implementation to other classes, but different naming and attack properties
    class Archer : CharacterBase
    {
        // constructor for name and health
        public Archer(string name, int health)
        {
            this.CharacterClass = "Archer";
            this.attackBehavior = new BowAttack();
            this.Name = name;
            this.Health = health;
        }

        // overloaded constructor for when values are not provided
        public Archer(string name) : this(name, GameConstants.Instance.DefaultHP)
        {

        }

        public Archer() : this(CharacterBase.AnonymousName + (++CharacterBase.anonymousCounter).ToString(), GameConstants.Instance.DefaultHP)
        {

        }
    }
}
