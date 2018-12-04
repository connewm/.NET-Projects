using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newman.RolePlayingGameInterfaces;

namespace Newman.RPGCore
{
    // character class for archer with similar implementation to other classes, but different naming and attack properties
    class ComputerWizard : CharacterBase
    {
        // constructor sets name and health
        public ComputerWizard(string name, int health)
        {
            this.CharacterClass = "Computer Wizard";
            this.attackBehavior = new BadGradeAttack();
            this.Name = name;
            this.Health = health;
        }

        // call the other constructor when certain values are missing
        public ComputerWizard (string name) : this(name, GameConstants.Instance.DefaultHP)
        {

        }

        public ComputerWizard() : this(CharacterBase.AnonymousName + (++CharacterBase.anonymousCounter).ToString(), GameConstants.Instance.DefaultHP)
        {

        }
    }   
}
