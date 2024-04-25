using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net.NetworkInformation;
using System.Drawing.Text;

namespace Space_Invaders_Style_Game_MOO_ICT
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        SerialPort serialPort;
        int score = 10;
        int lives = 5;
        int enemyBulletTimer = 300;
        int frequency1 = 3000;
        int invaderCounter = 0;
        PictureBox[] InvadersList;

        private void CancelMakeInvaders()
        {
            cancellationTokenSource?.Cancel();
        }
        static double Map(double value, double fromTarget, double toTarget)
        {
            return (value / 3.30) * (toTarget - fromTarget) + fromTarget;
        }
        
        public Form1(int frequency)
        {
            InitializeComponent();
            serialPort = new SerialPort("COM9", 9600);
            frequency1 = frequency;
            gameSetup();
        }
        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            try
            {
                String position = "lol";
                String fire = "fire";
                serialPort.Open();
                Console.WriteLine("Serial port opened.");
                string data = serialPort.ReadExisting();
                Console.WriteLine("Received data:" + data);
                string[] rawoutput = data.Split(' ');
                bool flag1 = false;
                bool flag2  = false;
                for (int i = 0; i < rawoutput.Length; i++)
                {
                    if (rawoutput[i].Equals("X"))
                    {
                        Console.WriteLine(rawoutput[i + 1]);
                        position = rawoutput[i + 1];

                        flag1 = true;
                    }
                    if (rawoutput[i].Equals("F"))
                    {
                        fire = rawoutput[i + 1];
                        Console.WriteLine(rawoutput[i]);
                        Console.WriteLine(rawoutput[i + 1]);
                        flag2 = true;
                    }
                    if (flag1 && flag2)
                    {
                        break;
                    }
                }
                double xpos1 = double.Parse(position);
                int fire1 = int.Parse(fire);
                Console.WriteLine("ParsedDouble: " + xpos1);
                if (xpos1 < 1)
                {
                    player.Left -= 16;
                }
                if (xpos1 > 2)
                {
                    player.Left += 16;
                }
                if (fire1 == 1)
                {
                    makeBullet("bullet");
                }
                
                Console.ReadLine();
            }
            catch (Exception ex)
            {   
                Console.WriteLine("Error :" , ex.Message);
            }
            finally
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
            }
            LivesTracker.Text = "Lives: " + lives;
            txtScore.Text = "Invaders:" + score;

            
            enemyBulletTimer -= 10;
            if (enemyBulletTimer < 1)
            {
                enemyBulletTimer = 300;
                makeBullet("InvaderBullet");
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Invader")
                {
                    x.Top += 10;
                    if (x.Top > 600)
                    {
                        this.Controls.Remove(x);
                        lives -= 1;
                        if (lives <= 0)
                        {
                            gameOver("Game Over");
                        }
                    }
                    foreach (Control y in this.Controls)
                    {
                        if (y is PictureBox && (string)y.Tag == "bullet")
                        {
                            if (y.Bounds.IntersectsWith(x.Bounds))
                            {
                                this.Controls.Remove(x);
                                this.Controls.Remove(y);
                                score -= 1;
                            }
                        }
                    }
                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        lives = 0;
                        this.Controls.Remove(x);
                        gameOver("Game Over");
                    }
                }
                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Top -= 20;
                    if (x.Top < 15)
                    {
                        this.Controls.Remove(x);
                    }
                }
                if (x is PictureBox && (string)x.Tag == "InvaderBullet")
                {
                    x.Top += 20;
                    if (x.Top > 620)
                    {
                        this.Controls.Remove(x);
                    }
                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        lives = 0;
                        this.Controls.Remove(x);
                        gameOver("Game Over");
                    }
                }
            }
            
            if (score == 0)
            {
                youWin(" You Win!");
            }
            
        }
       

        private async void makeInvaders()
        {
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            InvadersList = new PictureBox[11];
            int top = 0;

            Random random = new Random();
            for (int i = 0; i < InvadersList.Length; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }
                int randNum = random.Next(700);
                Console.WriteLine("Random: " +  randNum);
                InvadersList[i] = new PictureBox();
                InvadersList[i].Size = new Size(60, 50);
                InvadersList[i].Image = Properties.Resources.alien;
                InvadersList[i].Tag = "Invader";
                InvadersList[i].Left = randNum;
                InvadersList[i].Top = -50;
                InvadersList[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(InvadersList[i]);
                InvadersList[i].BringToFront();
                invaderCounter += 1;
                try
                {
                    await Task.Delay(frequency1, cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }

        private void gameSetup()
        {
            txtScore.Text = "Invaders:10";
            score = 10;
            lives = 5;
            enemyBulletTimer = 300;
            makeInvaders();
            gameTimer.Start();
        }
        
        private async void gameOver(string message)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            serialPort.Open();
            serialPort.Write("O");
            serialPort.Close();
            gamedone.Text = message;
            txtScore.Text = "Invaders:" + score;
            gameTimer.Stop();
            
            
            CancelMakeInvaders();
            
            removeAll();

            await Task.Delay(3000);
            gamedone.Text = "Next Game\nIn: 5";
            await Task.Delay(1000);
            gamedone.Text = "Next Game\nIn: 4";
            await Task.Delay(1000);
            gamedone.Text = "Next Game\nIn: 3";
            await Task.Delay(1000);
            gamedone.Text = "Next Game\nIn: 2";
            await Task.Delay(1000);
            gamedone.Text = "Next Game\nIn: 1";
            await Task.Delay(1000);
            gamedone.Text = " ";
            gameSetup();

        }

        private async void youWin(string message)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            serialPort.Open();
            serialPort.Write("W");
            serialPort.Close();
            gamedone.Text = message;
            txtScore.Text = "Invaders:" + score;
            gameTimer.Stop();
            invaderCounter = 0;
            
            
            CancelMakeInvaders();
            
            removeAll();

            await Task.Delay(3000);
            gamedone.Text = "Next Game\nIn: 5";
            await Task.Delay(1000);
            gamedone.Text = "Next Game\nIn: 4";
            await Task.Delay(1000);
            gamedone.Text = "Next Game\nIn: 3";
            await Task.Delay(1000);
            gamedone.Text = "Next Game\nIn: 2";
            await Task.Delay(1000);
            gamedone.Text = "Next Game\nIn: 1";
            await Task.Delay(1000);
            gamedone.Text = " ";
            gameSetup();

        }

        private void removeAll()
        {
            foreach (PictureBox i in InvadersList)
            {
                this.Controls.Remove(i);
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "bullet" || (string)x.Tag == "InvaderBullet")
                    {
                        this.Controls.Remove(x);
                    }
                    
                }
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void makeBullet(string bulletTag)
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.finalbullet;
            bullet.Size = new Size(6, 20);
            bullet.Tag = bulletTag;
            bullet.Left = player.Left + player.Width / 2;
            if ((string)bullet.Tag == "bullet")
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Write("B");
                }
                bullet.Top = player.Top - 20;
            }
            else if ((string)bullet.Tag == "InvaderBullet")
            {
                bullet.Top = -100;
            }
            this.Controls.Add(bullet);
            bullet.BringToFront();
            
        }
    }
}
