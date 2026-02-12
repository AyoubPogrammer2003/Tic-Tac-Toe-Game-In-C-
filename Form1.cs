using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game_In_C_.Properties;

namespace Tic_Tac_Toe_Game_In_C_
{
    public partial class Form1 : Form
    {
        stGameStatus GameStatus;
        enPlayerTurn PlayerTurn = enPlayerTurn.Player1;
        enum enPlayerTurn
        {
            Player1,Player2
        };

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameinProgress
        };

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public byte PlayCount;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"X = {e.X} , Y = {e.Y}";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color Black = Color.BlueViolet;

            Pen pen = new Pen(Black);
            pen.Width = 5;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;


            e.Graphics.DrawRectangle(pen, 300, 100,300, 250);
            e.Graphics.DrawLine(pen, 300, 180, 600,180);
            e.Graphics.DrawLine(pen, 300, 265, 600,265);
            e.Graphics.DrawLine(pen, 400, 100, 400,350);
            e.Graphics.DrawLine(pen, 500, 100, 500,350);
        }


        void EndGame()
        {
            lblPlayerTurn.Text = "Game Over";

            switch (GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblPlayerWin.Text = "   Player 1";
                    break;
                case enWinner.Player2:
                    lblPlayerTurn.Text = "   Player 2";
                    break;
                default:
                    lblPlayerTurn.Text = "    Draw";
                    break;
                    }

            MessageBox.Show("Game Over", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RestartGame(); 
        }
        bool CheckValues(PictureBox  Btrbx1,PictureBox Btrbx2,PictureBox  Btrbx3)
        {
            if (Btrbx1.Tag.ToString() != "?" && Btrbx1.Tag.ToString() == Btrbx2.Tag.ToString() &&
                Btrbx1.Tag.ToString() ==Btrbx3.Tag.ToString () )
            {
                Btrbx1.BackColor = Color.GreenYellow;
                Btrbx2.BackColor = Color.GreenYellow;
                Btrbx3.BackColor = Color.GreenYellow;

                if (Btrbx1.Tag.ToString() == "X") 
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

                    
            }
            GameStatus.GameOver = false;
            return false;
        }
        void CheckWinner()
        {
            if (CheckValues(pictureBox1, pictureBox2, pictureBox3))
                return;
            if (CheckValues(pictureBox4, pictureBox5, pictureBox6))
                return;
            if (CheckValues(pictureBox7, pictureBox8, pictureBox9))
                return;
            if (CheckValues(pictureBox1, pictureBox4, pictureBox7))
                return;
            if (CheckValues(pictureBox2, pictureBox5, pictureBox8))
                return;
            if (CheckValues(pictureBox3, pictureBox6, pictureBox9))
                return;
            if (CheckValues(pictureBox1, pictureBox5, pictureBox9))
                return;
            if (CheckValues(pictureBox3, pictureBox5, pictureBox7))
                return;
           

        }
        void ChangeImage(PictureBox Ptrbx)
        {
            if (Ptrbx.Tag.ToString() == "?")
            {

                switch (PlayerTurn)
                {
                    case enPlayerTurn.Player1:
                        Ptrbx.Image = Resources.pngtree_x_logo_icon_blue_neon_effect_for_png_image_9118534;
                        PlayerTurn = enPlayerTurn.Player2;
                        Ptrbx.Tag = "X";
                        lblPlayerTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        if (GameStatus.PlayCount >= 5)
                        {
                            CheckWinner();
                        }
                        break;

                    case enPlayerTurn.Player2:
                        Ptrbx.Image = Resources.pngtree_blue_purple_neon_border_cyber_circle_frame_png_image_6160584;
                        PlayerTurn = enPlayerTurn.Player1;
                        Ptrbx.Tag = "O";
                        lblPlayerTurn.Text = "Player 2";
                        GameStatus.PlayCount++;
                        if(GameStatus .PlayCount >=5)
                        {
                            CheckWinner();
                        }
                        break;
                }

            }
            else
            {
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(GameStatus .PlayCount ==9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }
       
        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            PictureBox Ptrbx = ((PictureBox)sender);
            ChangeImage(Ptrbx);      
        }

        void RestPictureBox(PictureBox Ptrbx)
        {
            if (Ptrbx.Tag.ToString() != "?") 
            {
                Ptrbx.Tag = "?";
                Ptrbx.BackColor = Color.Transparent;
                Ptrbx.Image = Resources.question_mark_transparent_neon_2;
            }
        }
        void RestartGame()
        {
            RestPictureBox(pictureBox1);
            RestPictureBox(pictureBox2);
            RestPictureBox(pictureBox3);
            RestPictureBox(pictureBox4);
            RestPictureBox(pictureBox5);
            RestPictureBox(pictureBox6);
            RestPictureBox(pictureBox7);
            RestPictureBox(pictureBox8);
            RestPictureBox(pictureBox9);


            PlayerTurn = enPlayerTurn.Player1;
            GameStatus.PlayCount = 0;
            GameStatus.Winner = enWinner.GameinProgress;
            GameStatus.GameOver = false;
            lblPlayerTurn.Text = "Player 1";
            lblPlayerWin.Text = "In Progress";
        }

        private void btnRestatrtGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        
    }
}
