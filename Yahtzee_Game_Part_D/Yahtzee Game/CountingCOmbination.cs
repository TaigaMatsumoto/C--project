using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game
{
    class CountingCombination:Combination
    {
        private int dieValue;

        public CountingCombination(ScoreType scoretype, Label score):base(score)
        {

        }

        public override void CalculateScore(int[] nums)
        {
            //Define the each calculation of combinations
        
        }

    }

}
