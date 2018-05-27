using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Yahtzee_Game
{
    public class Die
    {
        
        private int faceValue;
        private bool active = true;
        private Label label;
        private StreamReader rollfile;
        private bool DEBUG;
        private static Random random = new Random();

        public Die(Label die)
        {
            label = die;
        }

        public int FaceValue {
            get {
                return faceValue;
            }

        }
        public bool Active {
            get {
                return active;
            }
            set {
                active = value;
            }
        }


        public void Roll()
        {
            faceValue = random.Next(1, 7);
        }

        public void Load(Label label)
        {

        }
    }

}


