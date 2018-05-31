using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game
{
    [Serializable]
    class FixedScore:Combination
    {
        ScoreType scoretype;
        const int POINT_FOR_SML_STRAIGHT = 30;
        const int POINT_FOR_LAR_STRAIGHT = 40;
        const int POINT_FOR_FULLHOUSE = 25;
        const int POINT_FOR_YAHTZEE = 50;
        private List<bool> checkerForSmlLarStraight;
        private List<bool> checkerForFullHouse;

        public FixedScore(ScoreType scoretype, Label score) : base(score)
        {
            this.scoretype = scoretype;

        }

        public override void CalculateScore(int[] nums)
        {
            checkerForSmlLarStraight = new List<bool>();
            Sort(nums);
            //Check whether small straight or large straight

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] + 1 == nums[i + 1])
                {
                    checkerForSmlLarStraight.Add(true);
                }
            }
            switch (scoretype)
            {
                case ScoreType.SmallStraight:
                    //Small straight
                    if (checkerForSmlLarStraight.Count >= 3)
                    {
                        Points = POINT_FOR_SML_STRAIGHT;
                        done = true;
                    }
                    break;
                case ScoreType.LargeStraight:
                    if (checkerForSmlLarStraight.Count == 4)
                    {
                        Points = POINT_FOR_LAR_STRAIGHT;
                        done = true;
                    }
                    break;
                case ScoreType.FullHouse:
                    if (nums[0] == nums[1] && nums[0] == nums[2])
                    {
                        if (nums[0] == nums[3])
                        {
                            Points = 0;
                        }
                        else if (nums[3] == nums[4])
                        {
                            Points = POINT_FOR_FULLHOUSE;
                            done = true;
                        }
                        else
                        {
                            Points = 0;
                        }
                    }
                    else if (nums[0] == nums[1])
                    {
                        if(nums[0] == nums[2])
                        {
                             Points = 0; 
                        } else if (nums[2] == nums[3] && nums[2] == nums[4])
                        {
                            Points = POINT_FOR_FULLHOUSE;
                            done = true;
                        }
                        else
                        {
                            Points = 0;
                        }
                    }
                    break;
                case ScoreType.Yahtzee:
                    {
                        int yahtzeeNum = nums[0];
                        bool yahtzeeCombo = true;

                        for (int i = 1; i < nums.Length; i++)
                        {
                            if (nums[i] != yahtzeeNum)
                            {
                                yahtzeeCombo = false;
                            }
                        }
                        if (yahtzeeCombo)
                        {
                            Points = POINT_FOR_YAHTZEE;
                        }
                    }
                    break;
               
            } 
         
        }

      
    }
}
