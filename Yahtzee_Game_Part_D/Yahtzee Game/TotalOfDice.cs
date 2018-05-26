using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game
{
    class TotalOfDice : Combination
    {
        private int numberOfOneKind;

        public TotalOfDice(ScoreType scoretype, Label score) : base(score)
        {

        }
        public override void CalculateScore(int[] num)
        {

        }
    }
}
