using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game
{
    class FixedScore:Combination
    {
        ScoreType scoretype;

        public FixedScore(ScoreType scoretype, Label score) : base(score)
        {
            this.scoretype = scoretype;

        }
        
        public override void CalculateScore(int[] nums)
        {
            //algorithem will be here soon...
        }

      
    }
}
