using Newman.RolePlayingGameInterfaces;
using Newman.RPGCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFBattle
{
    /**
     * Connor Newman -- CSE 4253
     * This is the main window for a fully functioning RPG simulator, containing updated character and attack classes.
     * The Character classes dictate the CharacterImage.State element of a character which in turn uses the proper State image when rendered.
     * The Character classes use the updated Attack classes to determine which image to use. i.e. if a character is using their designated attack, their
     * image State becomes CharacterImage.CharacterState.Attacking which uses the Attacking image.
     * 
     * The simulation also utilizes multiple threads; one thread is used to run the combat simulation and another for the presentational data.
     * The simulation also redirects all printed "console" data to the Textbox console within the simulation thread.
     * */
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {        
           
            InitializeComponent();
            Console.SetOut(new TextBoxStreamWriter(test));
            createThread();
        }

        private void createThread()
        {
            
            ICharacter p1 = new WarriorImage(p1img, "Rhino", 20);
            ICharacter p2 = new DualWielderImage(p2img, "Mirage", 20);

            ICharacter e1 = new ComputerWizardImage(e1img, "Connor", 20);
            ICharacter e2 = new MageImage(e2img, "Banshee", 20);

            IList<ICharacter> l1 = new List<ICharacter>();
            IList<ICharacter> l2 = new List<ICharacter>();

            l1.Add(p1);
            l1.Add(p2);
            l2.Add(e1);
            l2.Add(e2);

            ICombat encounter = new Combat(l1, l2, "Good Guys", "Misunderstood Guys");

            var combatThread = new CombatThread(encounter);
            combatThread.Start();
        }

        
    }
}
