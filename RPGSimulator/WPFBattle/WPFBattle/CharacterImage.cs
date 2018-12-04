using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFBattle
{
    class CharacterImage : Image
    {
        // The two methods of updating image source make it thread safe -- it can be changed from either thread

        // enum which gives options for the 4 character states
        public enum CharacterState
        {
            Attacking, Defending, Idle, Dead
        }

        // holds the current character state
        private CharacterState state = CharacterState.Idle;
        //gets and sets character state
        public CharacterState State
        {
            get { return state; }
            set
            {
                state = value;
                // update displayed image as well when 'state' is changed
                this.Dispatcher.Invoke((Action)(() =>
                {
                    UpdateImageSource();
                }));
            }
        }

        // the following hold the image sources for the currently active character -- to be set in MainWindow
        public ImageSource IdleImageSource { get; set; }
        public ImageSource AttackingImageSource { get; set; }
        public ImageSource TakeDamageImageSource { get; set; }
        public ImageSource DeadImageSource { get; set; }

        // this method updates the current image source based on character state
        protected void UpdateImageSource()
        {
            // 'this' has an Image as well dictated by Source since it implements ...Media.Image
            switch (State)
            {
                case CharacterState.Attacking:
                    this.Source = AttackingImageSource;
                    break;
                case CharacterState.Defending:
                    this.Source = TakeDamageImageSource;
                    break;
                case CharacterState.Dead:
                    this.Source = DeadImageSource;
                    break;
                case CharacterState.Idle:
                default:
                    this.Source = IdleImageSource;
                    break;
            }
        }

        // override the OnRender method to ensure image source is updated with each render
        protected override void OnRender(DrawingContext dc)
        {
            //call UpdateImageSource() then base method
            UpdateImageSource();
            base.OnRender(dc);
        }

    }
}
