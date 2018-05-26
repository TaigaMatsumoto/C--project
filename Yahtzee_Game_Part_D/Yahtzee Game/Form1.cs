using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game
{
	public partial class Form1 : Form
	{
		const int NUM_DICES = 5;
		const int NUM_BUTTONS = 13;
		const int SCOREBUTTON_ARRAY_ELEMENTS = NUM_BUTTONS + 3;
		const int NUM_LABEL_FOR_SCORETOTALS = 19;

		string a = "a";

		private Label[] dice;
		private Button[] scoreButtons;
		private Label[] scoreTotals;
		private CheckBox[] checkBoxes;
		private Game game;

        public Form1()
		{
			InitializeComponent();
			InitializeLabelsAndButtons();
            //gameBindingSource.DataSource = players;
        }

		public void InitializeLabelsAndButtons()
		{
			dice = new Label[NUM_DICES] { die1, die2, die3, die4, die5 };
			scoreButtons = new Button[SCOREBUTTON_ARRAY_ELEMENTS] { Ones, Twos, Threes, Fours, Fives, Sixes, null, null, null,
																	ThreeOfAKind, FourOfAKind, FullHouse, SmallStraight,LargeStraight,Chance, Yahtzee};
			scoreTotals = new Label[NUM_LABEL_FOR_SCORETOTALS] { scoreLabel1 , scoreLabel2, scoreLabel3, scoreLabel4, scoreLabel5, scoreLabel6,
																subTotalLabel, bonusLabel, upperLabel, threeOfAKindLabel, fourOfAKindLabel, fullHouseLabel,
																smlStraightLabel, largeStraightLabel, chanceLabel, yahtzeeLabel, yahtzeeBonusLabel, lowerTotalLabel, grandTotalLabel};
			checkBoxes = new CheckBox[5] { roll_checkBox1, roll_checkBox2, roll_checkBox3, roll_checkBox4, roll_checkBox5 };
            scoreTotals[1] = new Label();
            
		}
		public Label[] GetDice()
		{
			return dice;
		}

		public Label[] GetScoreLabels()
		{
			return scoreTotals;
		}

		public void showPlayerName(string name)
		{
            playerName_label.Text = name;

        }
		public void EnableRollButton()
		{
			rollDice_button.Enabled = true;
		}

		public void DisableRollButton()
		{
			rollDice_button.Enabled = false;
		}
		public void EnableCheckBoxes()
		{
			foreach (CheckBox checkBox in checkBoxes)
			{
				checkBox.Enabled = true;
			}
		}
		public void DisableAndClearCheckBoxes()
		{
			foreach (CheckBox checkBox in checkBoxes)
			{
				checkBox.Enabled = false;
				checkBox.Checked = false;
			}
		}

		//Enable or disable the specified BUtton corresponding to the ScoreType parameter. 
		public void EnableScoreButton(ScoreType combo)
		{
			scoreButtons[(int)combo].Enabled = true;
		}

		public void DisableScoreButton(ScoreType combo)
		{

			scoreButtons[(int)combo].Enabled = false;
		}

		public void CheckCheckBox(int index)
		{
			checkBoxes[index].Checked = true;
		}
		public void ShowMessage(string message)
		{
			message_label.Text = message;
		}
		public void ShowOkButton()
		{
            ok_Button.Enabled = true;
            ok_Button.Visible = true;

        }
		public void StartNewGame()
		{
			game = new Game(this);
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void rollDice_button_Click(object sender, EventArgs e)
        {
            game.RollDice();
            foreach(CheckBox checkbox in checkBoxes)
            {
                checkbox.Enabled = true;
            }
            foreach(Button button in scoreButtons)
            {
                if(button != null)
                {
                    button.Enabled = true;
                }
            }
        }

        private void roll_checkBoxes_checkedChanged(object sender, EventArgs e)
        {
            foreach(CheckBox checkbox in checkBoxes)
            {
                if (checkbox.Checked)
                {
                    game.HoldDie(Array.IndexOf(checkBoxes, checkbox));
                }
                else
                {
                    game.ReleaseDie(Array.IndexOf(checkBoxes, checkbox));
                }
            }
        }

        private void ScoreButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = Array.IndexOf(scoreButtons, btn.Name);
            game.ScoreCombination((ScoreType)index);
            ShowOkButton();
        }

        private void newGameMenu_Click(object sender, EventArgs e)
        {
            StartNewGame();
            EnableRollButton();
            message_label.Text = "Roll 1";
            playerName_label.Text = "Player 1";
        }

        private void ok_Button_Click(object sender, EventArgs e)
        {
            game.NextTurn();
        }
    }

}

