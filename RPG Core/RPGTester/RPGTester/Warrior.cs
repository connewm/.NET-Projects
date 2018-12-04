using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newman.RolePlayingGameInterfaces;

namespace Newman.RPGCore
{
    class Warrior : CharacterBase
    {
        public Warrior(string name, int health)
        {
            this.CharacterClass = "Warrior";
            this.attackBehavior = new SwordAttack();
            this.Name = name;
            this.Health = health;
        }

        // additional overloaded constructors for instantiation with different parameters
        // these use a 'constructor initalizer' filling in the parameters for the upper
        // constructor using different default inputs to account for the missing parameters

        // constructor called with name, but no hp
        public Warrior (string name) : this(name, GameConstants.Instance.DefaultHP)
        {

        }

        // constructor to be called for anonymous player
        public Warrior() : this(CharacterBase.AnonymousName + (++CharacterBase.anonymousCounter).ToString(), GameConstants.Instance.DefaultHP)
        {

        }
    }
}
