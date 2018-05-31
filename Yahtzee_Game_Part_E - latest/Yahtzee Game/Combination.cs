using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game
{
    [Serializable]
    abstract class Combination:Score
    {
        private bool isYahtzee = false;
        private int yahtzeeNumber;
        public Combination(Label label): base (label)
        {
                
        }

        public abstract void CalculateScore(int[] scores);

        public void Sort(int[] nums)
        {
            Array.Sort(nums);
        }

        public bool IsYahtzee
        {
            get;
            set;
        }

        public int YahtzeeName
        {
            get;
            set;
        }

        public void CheckForYahtzee(int[] nums)
        {

        }
    }
}
