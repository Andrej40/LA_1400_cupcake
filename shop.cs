using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hütchenspiel;


namespace Hütchen_Shop
{
    public partial class shop : Form
    {
        //global Variables for money system
        public static double usrMoney;

        //global Variables for shop
        public static bool ownsSkin1 = false;
        public static bool ownsSkin2 = false;
        public static bool ownsItem = false;
        public static bool ownsBackground = false;

        public Form1 father;

        public shop()
        {
            InitializeComponent();

        }


        public shop(Form1 father)
        {
            InitializeComponent();
            this.father = father;

            usrMoney = father.usrMoney;


            UpdateBank(label9);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ownsSkin1 = PurchaseProcess(label5, label9);
            HideIfOwned(ownsSkin1, button1, label5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ownsSkin2 = PurchaseProcess(label6, label9);
            HideIfOwned(ownsSkin2, button2, label6);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ownsItem = PurchaseProcess(label7, label9);
            HideIfOwned(ownsItem, button3, label7);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ownsBackground = PurchaseProcess(label8, label9);
            HideIfOwned(ownsBackground, button4, label8);
        }



        //own functions        
        public void HideIfOwned(bool ownership, Button button, Label price)
        {
            if (ownership)
            {
                button.Visible = false;
                price.Visible = false;
            }
        }

        public bool PurchaseProcess(Label label, Label bank)
        {
            if (usrMoney > Convert.ToDouble(label.Text))
            {
                usrMoney -= Convert.ToDouble(label.Text);
                UpdateBank(bank);
                return true;
            }
            else
            {
                MessageBox.Show("You don't have enough money to purchase this item.", "Warning");
                return false;
            }
        }

        public void UpdateBank(Label bank)
        {
            bank.Text = "Bank: " + usrMoney;
        }
    }
}
