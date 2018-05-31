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
        private bool complete = false;
        public TotalOfDice(ScoreType scoretype, Label score) : base(score)
        {
            switch (scoretype)
            {
                case ScoreType.ThreeOfAKind:
                    //magic number:(
                    numberOfOneKind = 3;
                    break;
                case ScoreType.FourOfAKind:
                    //magic number:(
                    numberOfOneKind = 4;
                    break;
            }
        }
        public override void CalculateScore(int[] nums)
        {
            Sort(nums);
            if(numberOfOneKind == 3)
            {
                //magic number:(
                for (int i = 0; i < nums.Length - 2; i++)
                {
                   if(nums[i] == nums[i + 1] || nums[i] == nums[i + 2])
                    {
                        nums.Sum();
                    }
                }
            }
            else if(numberOfOneKind == 4)
            {
                //magic number:(
                for (int i = 0; i < nums.Length - 3; i++)
                {
                    if (nums[i] == nums[i + 1] || nums[i] == nums[i + 2] || 
                        nums[i] == nums[i + 3])
                    {
                        Points = nums.Sum();
                    }
                }
            }
        }
    }
}
