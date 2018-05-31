using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

    [Serializable]
    public class Game
    {
        public static string defaultPath = Environment.CurrentDirectory;
        private static string savedGameFile = defaultPath +"\\YahtzeeGame.dat";
        private const int NUM_OF_PLAYERS = 2;
        private const int NUM_OF_DICE = 5;
        private const int DEFAULT_INDEX = 0;
        private const int DEFAULT_FINISH = 0;
        private const int DEFAULT_INCREMENT = 1;
        private const int DEFAULT_NUM_ROLL = 1;
        private const int DEFAULT_FIRST_PLAYER = 0;
        private const string DEFAULT_NUM_DIE = "0";
        private BindingList<Player> players;
        private Player currentPlayer;
        private Die[] dice;
        private int currentPlayerIndex;
        private int playersFinished;
        private int numRolls;
        private int[] diceNum = new int[NUM_OF_DICE];
        [NonSerialized]
        private Form1 form;
        [NonSerialized]
        private Label[] dieLabels;
        private Label[] scoreLabels;
        private Button[] scoreButtons;
        private string[] testNames = new string[NUM_OF_PLAYERS]{"player 1", "Player 2"};


        public Game(Form1 formOneObj)
        {
            this.form = formOneObj;
            currentPlayerIndex = DEFAULT_INDEX;
            playersFinished = DEFAULT_FINISH;
            scoreLabels = form.GetScoresTotals();
            players = new BindingList<Player>() { 
                new Player("Player 1", scoreLabels)
        };
            dice = new Die[NUM_OF_DICE];
            initialize();
            numRolls = DEFAULT_NUM_ROLL;
            form.playerBindingSource.DataSource = players;
            currentPlayer = Players[currentPlayerIndex];

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
            scoreButtons = form.ScoreButtons();
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = new Die(dieLabels[i]);
            }

            //for (int i = 0; i < testNames.Length; i++)
            //{
            //    players.Add(new Player(testNames[i], scoreLabels));
            //}
        }
       
        public void NextTurn()
        {
            form.EnableCheckBoxes();
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
            form.ShowPlayerName(currentPlayer.Name);
            //Could not figure it out in Part C... See you in Part D
            form.playerScoreLabel.Text = "";
            form.message_label.Text = "Roll 1";
            //Later we might need to enable or disable some buttons or labels
            numRolls = DEFAULT_NUM_ROLL;
            form.rollDice_button.Enabled = true;
            foreach(Label die in dieLabels)
            {
                die.Text = "";
            }
            form.EnableRollButton();
            foreach(Label scorelabel in scoreLabels)
            {
                scorelabel.Text = "";
            }
        }
        public void RollDice()
        {
            for(int i = 0; i < dieLabels.Length; i++)
            {
                if (dice[i].Active)
                {
                    if(numRolls == 1)
                    {
                        //foreach (ScoreType scoretype in Enum.GetValues(typeof(ScoreType)))
                        //{
                        //    if (currentPlayer.IsAvailable(scoretype))
                        //    {
                        //        form.EnableScoreButton(scoretype);
                        //    }
                        //    else
                        //    {
                        //        form.DisableScoreButton(scoretype);
                        //    }
                        //    form.EnableScoreButton(scoretype);
                        //    if (!currentPlayer.IsAvailable(scoretype))
                        //    {
                        //        form.DisableScoreButton(scoretype);
                        //    }
                        //}
                        foreach(Button scorebutton in scoreButtons)
                        {
                            if(scorebutton != null)
                            {
                                if (currentPlayer.IsAvailable((ScoreType)Array.IndexOf(scoreButtons,scorebutton)))
                                {
                                    form.EnableScoreButton((ScoreType)Array.IndexOf(scoreButtons, scorebutton));
                                }
                                else
                                {
                                    form.DisableScoreButton((ScoreType)Array.IndexOf(scoreButtons, scorebutton));
                                }
                            }
                        }
                        scoreLabels = form.GetScoresTotals();
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
            for (int i = 0; i < NUM_OF_DICE; i++)
            {
                diceNum[i] = dice[i].FaceValue;
            }

            currentPlayer.ScoreCombination(scoretype, diceNum);
            currentPlayer.ShowScores();
            if (!currentPlayer.IsAvailable(scoretype))
            {
                form.DisableScoreButton(scoretype);
            }
        }
        /// <summary>
        /// Load a saved game from the default save game file
        /// </summary>
        /// <param name="form">the GUI form</param>
        /// <returns>the saved game</returns>
        public static Game Load(Form1 form)
        {
            Game game = null;
            if (File.Exists(savedGameFile))
            {
                try
                {
                    Stream bStream = File.Open(savedGameFile, FileMode.Open);
                    BinaryFormatter bFormatter = new BinaryFormatter();
                    game = (Game)bFormatter.Deserialize(bStream);
                    bStream.Close();
                    game.form = form;
                    game.ContinueGame();
                    return game;
                }
                catch
                {
                    MessageBox.Show("Error reading saved game file.\nCannot load saved game.");
                }
            }
            else {
                MessageBox.Show("No current saved game.");
            }
            return null;
        }
        /// <summary>
        /// Save the current game to the default save file
        /// </summary>
        public void Save()
        {
            try
            {
                Stream bStream = File.Open(savedGameFile, FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(bStream, this);
                bStream.Close();
                MessageBox.Show("Game saved");
            }
            catch (Exception e)
            {

                //   MessageBox.Show(e.ToString());
                MessageBox.Show("Error saving game.\nNo game saved.");
            }
        }

        /// <summary>
        /// Continue the game after loading a saved game
        /// 
        /// Assumes game was saved at the start of a player's turn before they had rolled dice.
        /// </summary>
        private void ContinueGame()
        {
            LoadLabels(form);
            for (int i = 0; i < dice.Length; i++)
            {
                //uncomment one of the following depending how you implmented Active of Die
                // dice[i].SetActive(true);
                dice[i].Active = true;
            }

            form.ShowPlayerName(currentPlayer.Name);
            form.EnableRollButton();
            form.EnableCheckBoxes();
            // can replace string with whatever you used
            form.ShowMessage("Roll 1");
            currentPlayer.ShowScores();
        }//end ContinueGame

        /// <summary>
        /// Link the labels on the GUI form to the dice and players
        /// </summary>
        /// <param name="form"></param>
        private void LoadLabels(Form1 form)
        {
            Label[] diceLabels = form.GetDice();
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i].Load(diceLabels[i]);
            }
            for (int i = 0; i < players.Count; i++)
            {
                players[i].Load(form.GetScoresTotals());
            }

        }

    }
}
