using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {

    [Serializable]
    abstract class Score {
		private int points;
        [NonSerialized]
        private Label label;
        protected bool done = false;
       

		public Score(Label labelName) {
			label = labelName;
		}
        
        public int Points {
			get {
				return points;
			}
			set {
                points = value;
			}

		}

        //public abstract void CalculateScore(int[] scores);

        public bool Done {
			get {
				return done;
			}
		}

		public void ShowScore() {
            if (points > 0 || done)
            {
                label.Text = points.ToString();
            }
            else
            {
                label.Text = "";
            }
        }

        public void Load(Label label)
        {
            this.label = label;
        } //end Load
    }
}
