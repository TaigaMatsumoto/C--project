using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace Yahtzee_Game
{

    public enum ScoreType
    {
        Ones, Twos, Threes, Fours, Fives, Sixes,
        SubTotal, BonusFor63Plus, SectionATotal,
        ThreeOfAKind, FourOfAKind, FullHouse,
        SmallStraight, LargeStraight, Chance, Yahtzee,
        YahtzeeBonus, SectionBTotal, GrandTotal
    }

    public class Game
    {
        private const int NUM_OF_PLAYERS = 2;
        private const int NUM_OF_DICE = 5;
        private const int DEFAULT_INDEX = 0;
        private const int DEFAULT_FINISH = 0;
        private const int DEFAULT_INCREMENT = 1;
        private const int DEFAULT_NUM_ROLL = 1;
        private BindingList<Player> players;
        private Player currentPlayer;
        private Die[] dice;
        private int currentPlayerIndex;
        private int playersFinished;
        private int numRolls;
        private Form1 form;
        private Label[] dieLabels;
        private Label[] scoreLabels;
        private string[] testNames = new string[NUM_OF_PLAYERS]{"player 1", "Player 2"};


        public Game(Form1 formOneObj)
        {
            currentPlayerIndex = DEFAULT_INDEX;
            players = new BindingList<Player>();
            playersFinished = DEFAULT_FINISH;
            scoreLabels = new Label[NUM_OF_PLAYERS];
            dice = new Die[NUM_OF_DICE];
            this.form = formOneObj;
            initialize();
            currentPlayer = players[currentPlayerIndex];
            numRolls = DEFAULT_NUM_ROLL;
            form.playerBindingSource.DataSource = Players;

        }
        public BindingList<Player> Players
        {
            get
            {
                return players;
            }
        }

        private void initialize()
        {
            dieLabels = form.GetDice();
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = new Die(dieLabels[i]);
            }

            for (int i = 0; i < testNames.Length; i++)
            {
                players.Add(new Player(testNames[i], scoreLabels));
            }
        }
       
        public void NextTurn()
        {
            if (currentPlayerIndex < players.Count - 1)
            {
                currentPlayerIndex += DEFAULT_INCREMENT;
            }
            else if (currentPlayerIndex == players.Count - 1)
            {
                currentPlayerIndex = DEFAULT_INDEX;
            }
            currentPlayer = players[currentPlayerIndex];
            //form.playerName_label.Text = currentPlayer.ToString();
            form.showPlayerName(currentPlayer.Name);
            //Could not figure it out in Part C... See you in Part D
            form.playerScoreLabel.Text = "";
            form.message_label.Text = "Roll 1";
            //Later we might need to enable or disable some buttons or labels
            numRolls = DEFAULT_NUM_ROLL;
            form.rollDice_button.Enabled = true;
        }
        public void RollDice()
        {
            for(int i = 0; i < dieLabels.Length; i++)
            {
                if (dice[i].Active)
                {
                    if(numRolls == 1)
                    {
                        scoreLabels = form.GetScoreLabels();
                        foreach(Label scorelabel in scoreLabels)
                        {
                            scorelabel.Text = ""; 
                        }
                        form.message_label.Text = "Roll 2 or choose a combination to score";
                    }
                    else if(numRolls == 2)
                    {
                        form.message_label.Text = "Roll 3 or choose a combination to score";
                        
                    }else if(numRolls == 3)
                    {
                        form.message_label.Text = @"Choose a combination to score. 
Your turn has ended - click OK";
                        form.rollDice_button.Enabled = false;
                    }
                    dice[i].Roll();
                    dieLabels[i].Text = dice[i].FaceValue.ToString();
                }
            }

            numRolls = numRolls + 1;

        }
        public void HoldDie(int index)
        {
            dice[index].Active = false;
        }
        public void ReleaseDie(int index)
        {
            dice[index].Active = true;
        }
        public void ScoreCombination(ScoreType scoretype)
        {
            form.ShowOkButton();
        }
        public static Game Load(Form1 form)
        {
            return null;
        }
        public void Save()
        {

        }


    }
}
