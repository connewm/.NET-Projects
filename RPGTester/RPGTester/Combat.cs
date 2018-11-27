using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newman.RolePlayingGameInterfaces;


namespace OhioState.RoleplayingGameLibrary
{
    public class Combat : ICombat
    {
        const int MaxCombatGroups = 2;

        private IList<ICharacter>[] combatGroups;
        private string[] groupNames;

        private IList<Tuple<int, int>> combatants;
        private Random rng = new Random();
        private int nextCombatant = Int32.MaxValue - 1;

        /// <summary>
        /// Create an instance to represent a combat between two parties.
        /// </summary>
        /// <param name="group1">The first combat group.</param>
        /// <param name="group2">The second combat group.</param>
        /// <param name="groupName1">The descriptive name of the first combat group.</param>
        /// <param name="groupName2">The descriptive name of the second combat group.</param>
        public Combat(IList<ICharacter> group1, IList<ICharacter> group2, string groupName1, string groupName2)
        {
            combatGroups = new List<ICharacter>[2];
            combatGroups[0] = group1;
            combatGroups[1] = group2;

            groupNames = new string[2];
            groupNames[0] = groupName1;
            groupNames[1] = groupName2;

            GenerateCombatantsList();
        }

        /// <summary>
        /// Perform a battle between the two groups until one is defeated.
        /// </summary>
        public virtual void AutoBattle()
        {
            DisplayBattleState();
            while (!CombatOver())
            {
                DoNextTurn();
                DisplayBattleState();
                System.Threading.Thread.Sleep(1000);
            }

            for (int groupIndex = 0; groupIndex < 2; groupIndex++)
            {
                if (GroupDead(groupIndex))
                {
                    Console.WriteLine(String.Format("The {0} has been defeated.", groupNames[groupIndex]));
                }
            }
        }

        private void GenerateCombatantsList()
        {
            int groupIndex, characterIndex;

            combatants = new List<Tuple<int, int>>();
            for (groupIndex = 0; groupIndex < combatGroups.Length; groupIndex++)
            {
                for (characterIndex = 0; characterIndex < combatGroups[groupIndex].Count; characterIndex++)
                {
                    combatants.Add(new Tuple<int, int>(groupIndex, characterIndex));
                }
            }
        }

        private void RandomizeCombatOrder()
        {
            int numberCombatants = combatants.Count;
            for (int i = 0; i < numberCombatants - 1; i++)
            {
                int j = i + rng.Next(numberCombatants - i);
                SwapCombatants(i, j);
            }
        }

        private void SwapCombatants(int i, int j)
        {
            if (i == j) return;
            Tuple<int, int> temp = combatants[i];
            combatants[i] = combatants[j];
            combatants[j] = temp;
        }

        bool CombatOver()
        {
            return (GroupDead(0) || GroupDead(1));
        }

        int NumLiving(int groupIndex)
        {
            int rv = 0;
            foreach (ICharacter character in combatGroups[groupIndex])
            {
                if (character.Health > 0)
                {
                    rv++;
                }
            }
            return rv;
        }

        bool GroupDead(int groupIndex)
        {
            return NumLiving(groupIndex) == 0;
        }

        private void DoNextTurn()
        {
            FindNextLivingCombatant();

            int attackerGroupIndex = combatants[nextCombatant].Item1;
            int attackerPartyIndex = combatants[nextCombatant].Item2;
            int enemyGroupIndex = (attackerGroupIndex + 1) % 2;

            ICharacter attacker = combatGroups[attackerGroupIndex][attackerPartyIndex];
            ICharacter target = ChooseRandomLivingTarget(enemyGroupIndex);

            if (target != null)
                attacker.PerformAttack(target);
        }

        private void FindNextLivingCombatant()
        {
            bool found = false;
            do
            {
                nextCombatant++;
                if (nextCombatant >= combatants.Count)
                {
                    RandomizeCombatOrder();
                    nextCombatant = 0;
                }

                int groupIndex = combatants[nextCombatant].Item1;
                int partyIndex = combatants[nextCombatant].Item2;

                if (combatGroups[groupIndex][partyIndex].Health > 0)
                    found = true;
            } while (!found);
        }

        private ICharacter ChooseRandomLivingTarget(int groupIndex)
        {
            int numLiving = NumLiving(groupIndex);
            if (numLiving > 0)
            {
                int choice = rng.Next(numLiving);
                foreach (ICharacter possibleTarget in combatGroups[groupIndex])
                {
                    if (possibleTarget.Health > 0)
                    {
                        if (choice-- == 0)
                            return possibleTarget;
                    }
                }
            }
            return null;
        }

        private void DisplayBattleState()
        {
            int groupIndex;
            for (groupIndex = 0; groupIndex < 2; groupIndex++)
            {
                Console.WriteLine(String.Format("------------{0}-----------", groupNames[groupIndex]));
                foreach (ICharacter combatant in combatGroups[groupIndex])
                {
                    Console.WriteLine(combatant);
                }
                Console.WriteLine("----------------------------------");
            }
        }
    }
}
