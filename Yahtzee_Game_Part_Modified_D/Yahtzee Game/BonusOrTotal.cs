using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game
{
    class BonusOrTotal:Score
    {
        private Label label;
        public BonusOrTotal(Label label):base(label) {
            //this.label = label;
            
        }
    }
}
