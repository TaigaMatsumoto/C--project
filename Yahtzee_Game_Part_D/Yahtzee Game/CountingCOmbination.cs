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
        const int DEFAULT_NUM_FOR_ARRAY = 0;
        private int dieValue;

        public CountingCombination(ScoreType scoretype, Label score):base(score)
        {
            switch (scoretype)
            {
                case ScoreType.Ones:
                    dieValue = 1;
                    break;
                case ScoreType.Twos:
                    dieValue = 2;
                    break;
                case ScoreType.Threes:
                    dieValue = 3;
                    break;
                case ScoreType.Fours:
                    dieValue = 4;
                    break;
                case ScoreType.Fives:
                    dieValue = 5;
                    break;

            }
        }

        public override void CalculateScore(int[] dieNums)
        {
            int numInArray = DEFAULT_NUM_FOR_ARRAY;
            foreach(int dieNum in dieNums)
            {
                if(dieNum == dieValue)
                {
                    numInArray++;
                }
            }

            dieValue *= numInArray;

            
            //Define the each calculation of combinations
        
        }

    }

}
