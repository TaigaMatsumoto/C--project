using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game
{
    abstract class Combination:Score
    {
        public Combination(Label label): base (label)
        {
                
        }

        public abstract void CalculateScore(int[] scores);

        public void Sort(int[] nums)
        {
            Array.Sort(nums);
        }
    }
}
