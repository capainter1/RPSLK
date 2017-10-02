using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RPSLK
{
    public partial class frmMain : Form
    {
        String Player1Name = "Player 1";
        String Player2Name = "Player 2";
        int Player1Choice, Player2Choice, Winner;
        int Round = 0;
        int Player1Score = 0;
        int Player2Score = 0;

        

        public frmMain()
        {
            InitializeComponent();

            btnRockTop.Click += new EventHandler(Player1Button_Click);
            btnPaperTop.Click += new EventHandler(Player1Button_Click);
            btnScissorsTop.Click += new EventHandler(Player1Button_Click);
            btnLizardTop.Click += new EventHandler(Player1Button_Click);
            btnSpockTop.Click += new EventHandler(Player1Button_Click);

            btnRockBottom.Click += new EventHandler(Player2Button_Click);
            btnPaperBottom.Click += new EventHandler(Player2Button_Click);
            btnScissorsBottom.Click += new EventHandler(Player2Button_Click);
            btnLizardBottom.Click += new EventHandler(Player2Button_Click);
            btnSpockBottom.Click += new EventHandler(Player2Button_Click);
        }
        private void ResetControls()
        {
            lblPlayerOneScore.Text = Player1Name;
            lblPlayerTwoScore.Text = Player2Name;
            grpPlayerOne.Text = Player1Name;
            grpPlayerTwo.Text = Player2Name;
            grpPlayerOne.Enabled = true;
            btnRound.Enabled = true;
            lblWinner.Text = string.Empty;
            ClearColors();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Player1Name = txtPlayerOne.Text;
            Player2Name = txtPlayerTwo.Text;
            ResetControls();
            btnStart.Enabled = false;
        }

        private void btnRound_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Player1Name = "Player 1";
            Player2Name = "Player 2";
            txtPlayerOne.Text = string.Empty;
            txtPlayerTwo.Text = string.Empty;
            Player1Score = 0;
            Player2Score = 0;
            Round = 0;
            txtPlayerOneScore.Text = Player1Score.ToString();
            txtPlayerTwoScore.Text = Player2Score.ToString();
            txtGameHistory.Text = string.Empty;
            EnableStart();
            ClearColors();
        }

        private void EnableStart()
        {
            grpPlayerOne.Enabled = false;
            lblWinner.Text = string.Empty;
            if (txtPlayerOne.Text.Length > 0 && txtPlayerTwo.Text.Length > 0)
            {btnStart.Enabled = true;}      else { btnStart.Enabled = false; }
        }

        private void txtPlayerOne_TextChanged(object sender, EventArgs e)
        {EnableStart();}

        private void txtPlayerTwo_TextChanged(object sender, EventArgs e)
        {EnableStart();}

        private void GoToPlayerTwo()
        {
            grpPlayerOne.Enabled = false;
            grpPlayerTwo.Enabled = true;
            
        }
        
        private void DetermineWinner()
        {
            grpPlayerTwo.Enabled = false;

            if ((Player1Choice == 1 && Player2Choice == 3)
                || (Player1Choice == 1 && Player2Choice == 4))
            {
                Winner = 1;
                Player1Score++;
            }

            else if ((Player1Choice == 2 && Player2Choice == 5)
                || (Player1Choice == 2 && Player2Choice == 1))
            {
                Winner = 1;
                Player1Score++;
            }
            else if ((Player1Choice == 3 && Player2Choice == 2)
                || (Player1Choice == 3 && Player2Choice == 4))
            {
                Winner = 1;
                Player1Score++;
            }
            else if ((Player1Choice == 4 && Player2Choice == 2)
                || (Player1Choice == 4 && Player2Choice == 5))
            {
                Winner = 1;
                Player1Score++;
            }
            else if ((Player1Choice == 5 && Player2Choice == 1)
                || (Player1Choice == 5 && Player2Choice == 3))
            {
                Winner = 1;
                Player1Score++;
            }
            else if (Player1Choice == Player2Choice)
            {
                Winner = 0;
            }
            /*
                if(Player1choice == "Rock" && (P2C == "Scissors" || p2c == "Lizard")) 
                if(p1x == "Rock" && p2c == "Scissors"){
                rock green

             
                else if((Player1Choice == 1 && Player2Choice == 1)
                || (Player1Choice == 2 && Player2Choice == 2)
                || (Player1Choice == 3 && Player2Choice == 3)
                || (Player1Choice == 4 && Player2Choice == 4)
                || (Player1Choice == 5 && Player2Choice == 5))
            {
                Winner = 0;
            }
            */
            else
            {
                Winner = 2;
                Player2Score++;
            }

            Round++;
            GameHistory();
            ColorChange();
        }

        private void GameHistory()
        {
            String[] Game = new String[6];
            Game[0] = "null";
            Game[1] = "Rock";
            Game[2] = "Paper";
            Game[3] = "Scissors";
            Game[4] = "Lizard";
            Game[5] = "Spock";

            txtGameHistory.AppendText(Player1Name + " vs. " + Player2Name
                + ". Round: " + Round + "\r\n"
                + Player1Name + ": " + Game[Player1Choice] + "\r\n"
                + Player2Name + ": " + Game[Player2Choice] + "\r\n");           

            if(Player1Choice == 1)
            {
                if(Player2Choice == 2){ txtGameHistory.AppendText("Paper covers Rock."); }
                else if (Player2Choice == 3) { txtGameHistory.AppendText("Rock crushes Scissors."); }
                else if (Player2Choice == 4) { txtGameHistory.AppendText("Rock crushes Lizard."); }
                else if (Player2Choice == 5) { txtGameHistory.AppendText("Spock vaporizes Rock."); }
                else {  }
            }
            else if(Player1Choice == 2)
            {
                if (Player2Choice == 1) { txtGameHistory.AppendText("Paper covers Rock."); }
                else if (Player2Choice == 3) { txtGameHistory.AppendText("Scissors cut Paper."); }
                else if (Player2Choice == 4) { txtGameHistory.AppendText("Lizard eats Paper."); }
                else if (Player2Choice == 5) { txtGameHistory.AppendText("Paper disproves Spock."); }
                else {  }
            }
            else if(Player1Choice == 3)
            {
                if (Player2Choice == 1) { txtGameHistory.AppendText("Rock crushes Scissors."); }
                else if (Player2Choice == 2) { txtGameHistory.AppendText("Scissors cuts Paper."); }
                else if (Player2Choice == 4) { txtGameHistory.AppendText("Scissors decapitates Lizard."); }
                else if (Player2Choice == 5) { txtGameHistory.AppendText("Spock smashes Scissors."); }
                else {  }
            }
            else if(Player1Choice == 4)
            {
                if (Player2Choice == 1) { txtGameHistory.AppendText("Rock crushes Lizard."); }
                else if (Player2Choice == 2) { txtGameHistory.AppendText("Lizard eats Paper."); }
                else if (Player2Choice == 3) { txtGameHistory.AppendText("Scissors decapitates Lizard."); }
                else if (Player2Choice == 5) { txtGameHistory.AppendText("Lizard poisons Spock."); }
                else {  }
            }
            else if (Player1Choice == 5)
            {
                if (Player2Choice == 1) { txtGameHistory.AppendText("Spock vaporizes Rock."); }
                else if (Player2Choice == 2) { txtGameHistory.AppendText("Paper disproves Spock."); }
                else if (Player2Choice == 3) { txtGameHistory.AppendText("Spock smashes Scissors."); }
                else if (Player2Choice == 4) { txtGameHistory.AppendText("Lizard poisons Spock."); }
                else {  }
            }
            else { }


            if (Winner == 1)
            {
                txtGameHistory.AppendText("\r\n" + Player1Name + " Wins! \r\n");
                lblWinner.Text = Player1Name + " wins!";
            }
            else if(Winner == 0)
            {
                txtGameHistory.AppendText("It's a tie! No one wins. \r\n");
                lblWinner.Text = "It's a tie!";
            }
            else
            {
                txtGameHistory.AppendText("\r\n" + Player2Name + " Wins! \r\n");
                lblWinner.Text = Player2Name + " wins!";
            }

            txtPlayerOneScore.Text = Player1Score.ToString();
            txtPlayerTwoScore.Text = Player2Score.ToString();
        }

        private void ColorChange()
        {
            if(Winner == 1)
            {
                if (Player1Choice == 1) { btnRockTop.BackColor = Color.Green; }
                else if (Player1Choice == 2) { btnPaperTop.BackColor = Color.Green; }
                else if (Player1Choice == 3) { btnScissorsTop.BackColor = Color.Green; }
                else if (Player1Choice == 4) { btnLizardTop.BackColor = Color.Green; }
                else if (Player1Choice == 5) { btnSpockTop.BackColor = Color.Green; }
                else { }

                if (Player2Choice == 1) { btnRockBottom.BackColor = Color.Red; }
                else if (Player2Choice == 2) { btnPaperBottom.BackColor = Color.Red; }
                else if (Player2Choice == 3) { btnScissorsBottom.BackColor = Color.Red; }
                else if (Player2Choice == 4) { btnLizardBottom.BackColor = Color.Red; }
                else if (Player2Choice == 5) { btnSpockBottom.BackColor = Color.Red; }
            }
            else if(Winner == 2)
            {
                if (Player2Choice == 1) { btnRockBottom.BackColor = Color.Green; }
                else if (Player2Choice == 2) { btnPaperBottom.BackColor = Color.Green; }
                else if (Player2Choice == 3) { btnScissorsBottom.BackColor = Color.Green; }
                else if (Player2Choice == 4) { btnLizardBottom.BackColor = Color.Green; }
                else if (Player2Choice == 5) { btnSpockBottom.BackColor = Color.Green; }

                if (Player1Choice == 1) { btnRockTop.BackColor = Color.Red; }
                else if (Player1Choice == 2) { btnPaperTop.BackColor = Color.Red; }
                else if (Player1Choice == 3) { btnScissorsTop.BackColor = Color.Red; }
                else if (Player1Choice == 4) { btnLizardTop.BackColor = Color.Red; }
                else if (Player1Choice == 5) { btnSpockTop.BackColor = Color.Red; }
                else { }
            }
            if(Winner == 0)
            {
                if (Player2Choice == 1) { btnRockBottom.BackColor = Color.LightYellow; }
                else if (Player2Choice == 2) { btnPaperBottom.BackColor = Color.LightYellow; }
                else if (Player2Choice == 3) { btnScissorsBottom.BackColor = Color.LightYellow; }
                else if (Player2Choice == 4) { btnLizardBottom.BackColor = Color.LightYellow; }
                else if (Player2Choice == 5) { btnSpockBottom.BackColor = Color.LightYellow; }

                if (Player1Choice == 1) { btnRockTop.BackColor = Color.LightYellow; }
                else if (Player1Choice == 2) { btnPaperTop.BackColor = Color.LightYellow; }
                else if (Player1Choice == 3) { btnScissorsTop.BackColor = Color.LightYellow; }
                else if (Player1Choice == 4) { btnLizardTop.BackColor = Color.LightYellow; }
                else if (Player1Choice == 5) { btnSpockTop.BackColor = Color.LightYellow; }
                else { }
            }
        }

        private void ClearColors()
        {
            btnRockTop.BackColor = Color.FromKnownColor(KnownColor.Control);
            btnPaperTop.BackColor = Color.FromKnownColor(KnownColor.Control);
            btnScissorsTop.BackColor = Color.FromKnownColor(KnownColor.Control);
            btnLizardTop.BackColor = Color.FromKnownColor(KnownColor.Control);
            btnSpockTop.BackColor = Color.FromKnownColor(KnownColor.Control);

            btnRockBottom.BackColor = Color.FromKnownColor(KnownColor.Control);
            btnPaperBottom.BackColor = Color.FromKnownColor(KnownColor.Control);
            btnScissorsBottom.BackColor = Color.FromKnownColor(KnownColor.Control);
            btnLizardBottom.BackColor = Color.FromKnownColor(KnownColor.Control);
            btnSpockBottom.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
       
        private void Player1Button_Click(object sender, EventArgs e)
        {
            switch((sender as Button).Name)
            {
                case "btnRockTop":
                    Player1Choice = 1;
                    break;
                case "btnPaperTop":
                    Player1Choice = 2;
                    break;
                case "btnScissorsTop":
                    Player1Choice = 3;
                    break;
                case "btnLizardTop":
                    Player1Choice = 4;
                    break;
                case "btnSpockTop":
                    Player1Choice = 5;
                    break;
                default:
                    break;
            }

            GoToPlayerTwo();
        }

        private void Player2Button_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "btnRockBottom":
                    Player2Choice = 1;
                    break;
                case "btnPaperBottom":
                    Player2Choice = 2;
                    break;
                case "btnScissorsBottom":
                    Player2Choice = 3;
                    break;
                case "btnLizardBottom":
                    Player2Choice = 4;
                    break;
                case "btnSpockBottom":
                    Player2Choice = 5;
                    break;
                default:
                    break;
            }

            DetermineWinner();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
