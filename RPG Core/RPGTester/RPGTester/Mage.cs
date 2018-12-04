using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newman.RolePlayingGameInterfaces;

namespace Newman.RPGCore
{
    class Mage : CharacterBase 
    {
        // Constructor sets name and health
        public Mage(string name, int health)
        {
            this.CharacterClass = "Mage";
            this.attackBehavior = new FireAttack();
            this.Name = name;
            this.Health = health;
        }

        // additional overloaded constructors for instantiation with different parameters
        // these use a 'constructor initalizer' filling in the parameters for the upper
        // constructor using different default inputs to account for the missing parameters

        // constructor called with name, but no hp
        public Mage (string name) : this(name, GameConstants.Instance.DefaultHP)
        {

        }

        //constructor for anonymous player
        public Mage() : this(CharacterBase.AnonymousName + (++CharacterBase.anonymousCounter).ToString(), GameConstants.Instance.DefaultHP)
        {

        }
    }
}
