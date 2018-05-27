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
        private List<bool> test1;
        public FixedScore(ScoreType scoretype, Label score) : base(score)
        {
            this.scoretype = scoretype;

        }
        
        public override void CalculateScore(int[] nums)
        {
            test1 = new List<bool>();
            Sort(nums);
            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] == nums[i+1] + 1)
                {
                    test1.Add(true);
                }
            }
            if (test1.Count >= 3)
            {
                if(test1.Count == 4)
                {

                }
            }
            
            //algorithem will be here soon...
        }

      
    }
}
