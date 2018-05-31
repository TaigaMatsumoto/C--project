using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Yahtzee_Game
{
    [Serializable]
    public class Die
    {
        private static string rollFileName = Game.defaultPath + "\\basictestrolls.txt";
        private int faceValue;
        private bool active = true;
        [NonSerialized]
        private Label label;
        private static StreamReader rollFile = new StreamReader(rollFileName);
        private bool DEBUG = true;
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
            if (!DEBUG)
            {
                faceValue = random.Next(1, 7);
            }else {
                faceValue = int.Parse(rollFile.ReadLine());
                label.Text = faceValue.ToString();
                label.Refresh();
            }
        }

        public void Load(Label label)
        {
            this.label = label;
            if (faceValue == 0)
            {
                label.Text = string.Empty;
            }
            else {
                label.Text = faceValue.ToString();
            }
        }//end Load

    }

}


