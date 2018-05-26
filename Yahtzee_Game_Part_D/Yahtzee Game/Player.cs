using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {
	public class Player {
		private string name;
		private int combinationsToDO;
		private Score[] scores;
		private int grandTotal;
		
		public Player(string playerName, Label[] scoreTotals) {
			name = playerName;
		}

		public string Name {
			get {
				return name;
            }
            set
            {
                name = value;
            }
		}
		public void ScoreCombination(ScoreType scoretype, int[] integers) {

		}

		public int GrandTotal {
			get {
				return grandTotal;
			}
            set
            {
                grandTotal = value;
            }
		}

		public bool IsAvailable(ScoreType scoretype) {
			return true;
		}

		public void ShowScores() {

		}

		public bool IsFinished() {
			if(combinationsToDO == 0) {
				return true;
			} else {
				return false;
			}
		}

		//public Label[] Load(){
			
		//}
	}
}
