using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hütchen_Shop;

namespace Hütchenspiel
{
    public partial class Form1 : Form
    {
        public static bool win = false;
        public static int rndmNum;
        public static int streak = 0;
        public static bool ownsItem = false;
        public static Form1 myself;
        public double usrMoney = 1000;
        public static double bet = 0;
        public static double multiplier = 1.2;



        public static int randomnum()
        {
            Random random = new Random();
            int randomnumber = random.Next(1, 4);
            return randomnumber;
        }

        public Form1()
        {
            InitializeComponent();

            rndmNum = randomnum();
            ShowBall(pictureBox4, pictureBox5, pictureBox6);


            label1.Text = "Balance: " + usrMoney.ToString();


            if (!(ownsItem))
            {
                button6.Visible = false;
            }

            //todo: remove or modify before release
            label3.Text = rndmNum.ToString();
            label4.Visible = false;
        }

        public void button4_Click(object sender, EventArgs e)
        {
            if (win)
            {
                streak++;
                label2.Text = $"Streak: {streak}";
            }
            else if (!(win))
            {
                streak = 0;
                label2.Text = "Streak: LOST";
            }

            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
            rndmNum = randomnum();

            ShowBall(pictureBox4, pictureBox5, pictureBox6);
            label4.Visible = false;

            textBox1.Visible = true;
            button7.Visible = true;

            Betmulti();

            label1.Text = "Balance: " + usrMoney.ToString();
            win = false;

            // hide x-ray if not bought
            if (!(ownsItem))
            {
                button6.Visible = false;
            }

            //todo: remove or modify before release
            label3.Text = Convert.ToString(rndmNum);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            win = CheckIfTrue(rndmNum, 1);
            label4.Text = ReturnFeedback(win);
            label4.Visible = true;
            HideCups(pictureBox1, pictureBox2, pictureBox3, button1, button2, button3, button4);
        }

        public void button2_Click(object sender, EventArgs e)
        {
            win = CheckIfTrue(rndmNum, 2);
            label4.Text = ReturnFeedback(win);
            label4.Visible = true;
            HideCups(pictureBox1, pictureBox2, pictureBox3, button1, button2, button3, button4);
        }

        public void button3_Click(object sender, EventArgs e)
        {
            win = CheckIfTrue(rndmNum, 3);
            label4.Text = ReturnFeedback(win);
            label4.Visible = true;
            HideCups(pictureBox1, pictureBox2, pictureBox3, button1, button2, button3, button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            shop myShop = new shop(this);
            myShop.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string result = "";
            switch (rndmNum)
            {
                case 1:
                    result = "The ball is under the LEFT cup.";
                    break;

                case 2:
                    result = "The ball is under the MIDDLE cup.";
                    break;

                case 3:
                    result = "The ball is under the RIGHT cup.";
                    break;
                default:
                    result = "There was an Error! Please restart the game :(";
                    break;
            }
            MessageBox.Show(result, "X-Ray");
            ownsItem = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool confirm = false;
            try
            {
                bet = Convert.ToInt32(textBox1.Text);
                confirm = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte geben Sie eine Zahl ein!");
            }
            textBox1.Text = "";

            if (confirm)
            {
                textBox1.Visible = false;
                button7.Visible = false;
            }
        }

        public static bool CheckIfTrue(int rndmNum, int guess)
        {
            if (rndmNum == guess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void HideCups(PictureBox picone, PictureBox pictwo, PictureBox picthree, Button butone, Button buttwo, Button butthree, Button butfour)
        {
            picone.Visible = false;
            pictwo.Visible = false;
            picthree.Visible = false;
            butone.Visible = false;
            buttwo.Visible = false;
            butthree.Visible = false;
            butfour.Visible = true;
        }

        public static void ShowBall(PictureBox four, PictureBox five, PictureBox six)
        {
            HideBalls(four, five, six);
            if (rndmNum == 1)
            {
                four.Visible = true;
            }
            else if (rndmNum == 2)
            {
                five.Visible = true;
            }
            else
            {
                six.Visible = true;
            }
        }

        public static void HideBalls(PictureBox four, PictureBox five, PictureBox six)
        {
            four.Visible = false;
            five.Visible = false;
            six.Visible = false;
        }

        public static string ReturnFeedback(bool win)
        {
            if (win)
            {
                return "Correct guess!";
            }
            else
            {
                return "Wrong!\nTry again.";
            }
        }

        public void Multimachine()
        {
            usrMoney = usrMoney + bet * multiplier;
        }

        public void Betmulti()
        {
            if (win)
            {
                Multimachine();
            }
            else if (win == false)
            {
                usrMoney -= bet;
            }
            bet = 0;
        }
    }
}
