using Newman.RPGCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPFBattle
{
    class CombatThread
    {
        // stores and eventually initiates the combat
        private ICombat encounter;
        // creates a new worker thread which executes until combat is finished
        private Thread thread;

        // initiates the new worker thread which begins execution of battle using an anonymous function upon worker thread initiation
        public void Start()
        {
            thread = new System.Threading.Thread(() => //give this code
            {
                encounter.AutoBattle();
            });
            thread.Name = "GameThread";
            thread.Start();
        }


        // aborts currently running worker thread as indiicated by state of Combat object
        public void Deactivate()
        {
            thread.Abort();
        }

        // constructor for instantiating the Combat object
        public CombatThread(ICombat encounter)
        {
            this.encounter = encounter;
        }
    }
}
