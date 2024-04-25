using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Space_Invaders_Style_Game_MOO_ICT
{
    public partial class StartScreen : Form
    {
        SerialPort serialPort;
        public StartScreen()
        {
            InitializeComponent();
            serialPort = new SerialPort("COM9", 9600);
            startupmenuTimer.Start();
        }

        private void loadEasy(object sender, EventArgs e)
        {
            Form1 game1 = new Form1(5000);
            game1.Show();

        }

        private void loadMedium(object sender, EventArgs e)
        {
            Form1 game1 = new Form1(3000);
            game1.Show();
        }

        private void loadHard(object sender, EventArgs e)
        {
            Form1 game1 = new Form1(1000);
            game1.Show();
        }

        private void startupMenuTimer(object sender, EventArgs e)
        {
            int mode = 0;
            Console.Write("Startup Timer");
            try
            {
                
                serialPort.Open();
                String data = serialPort.ReadExisting();
                string[] rawoutput = data.Split(' ');
                for (int i = 0; i < rawoutput.Length; i++)
                {
                    if (rawoutput[i] == "M")
                    {
                        mode = int.Parse(rawoutput[i + 1]);
                    }
                    
                }
                
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Error :", ex.Message);
            }
            finally
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
            }
            if (mode == 1)
            {
                Form1 game1 = new Form1(5000);
                startupmenuTimer.Stop();
                game1.Show();
            
            }
            if (mode == 2)
            {
                Form1 game1 = new Form1(3000);
                startupmenuTimer.Stop();
                game1.Show();
          
            }
            if (mode == 3)
            {
                Form1 game1 = new Form1(1000);
                startupmenuTimer.Stop();
                game1.Show();
         
            }

        }
    }
}
