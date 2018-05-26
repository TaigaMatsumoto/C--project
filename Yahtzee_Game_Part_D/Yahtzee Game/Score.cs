    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {
	class Score {
		private int points;
		private Label label;
		protected bool done;

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

		public bool Done {
			get {
				return done;
			}
		}

		public void ShowScore() {
			if (done) {
				label.Text = points.ToString();
			}
		}

		public void Load(Label label) {

		}
	}
}
