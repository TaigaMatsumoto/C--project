using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game
{
    [Serializable]
    class BonusOrTotal:Score
    {
        public BonusOrTotal(Label label):base(label) {
           
        }
    }
}
