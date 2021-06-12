using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double a = 0, b = 0, c = 0;
        public char z = '/';
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }
        

        //ЭТО РАВНО
        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                b = Convert.ToDouble(textBox1.Text);
                textBox1.Text = "";
                switch (z)
                {
                    case '+':
                        c = a + b;
                        break;
                    case '-':
                        c = a - b;
                        break;
                    case '*':
                        c = a * b;
                        break;
                    case '/':
                        c = a / b;
                        break;
                }
                textBox1.Text = Convert.ToString(c);
            }
            catch (Exception)
            {

            }
            
    
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            a = 0;
            b = 0;
            c = 0;
        }


        private void button16_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            z = (sender as Button).Text[0];
            textBox1.Clear();
        }
    }
}
