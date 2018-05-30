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
        private Combination combination;
        private ScoreType[] scoretype = (ScoreType[])Enum.GetValues(typeof(ScoreType));
        private Form1 form = new Form1();
        private Label[] scoreTotals;
        public Player(string playerName, Label[] scoreTotals) {
			name = playerName;
            this.scoreTotals = scoreTotals;
            instantiate();
        }
        private void instantiate()
        {
            scores = new Score[scoreTotals.Length];
            for(int i = 0; i < scores.Length; i++)
            {
                switch (scoretype[i]) {
                    case ScoreType.Ones:
                    case ScoreType.Twos:
                    case ScoreType.Threes:
                    case ScoreType.Fours:
                    case ScoreType.Fives:
                    case ScoreType.Sixes:
                        scores[i] = new CountingCombination(scoretype[i], scoreTotals[i]);
                        break;
                    case ScoreType.SmallStraight:
                    case ScoreType.LargeStraight:
                    case ScoreType.FullHouse:
                    case ScoreType.Yahtzee:
                        scores[i] = new FixedScore(scoretype[i], scoreTotals[i]);
                        break;
                    case ScoreType.ThreeOfAKind:
                    case ScoreType.FourOfAKind:
                    case ScoreType.Chance:
                        scores[i] = new TotalOfDice(scoretype[i], scoreTotals[i]);
                        break;
                    case ScoreType.BonusFor63Plus:
                    case ScoreType.SubTotal:
                    case ScoreType.SectionATotal:
                    case ScoreType.YahtzeeBonus:
                    case ScoreType.SectionBTotal:
                    case ScoreType.GrandTotal:
                        scores[i] = new BonusOrTotal(scoreTotals[i]);
                        break;

                }
            }
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

        //I have no idea
		public void ScoreCombination(ScoreType scoretype, int[] integers) {
            combination = (Combination)scores[(int)scoretype];
            combination.CalculateScore(integers);
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
            foreach(Score score in scores)
            {
                score.ShowScore();
            }
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
