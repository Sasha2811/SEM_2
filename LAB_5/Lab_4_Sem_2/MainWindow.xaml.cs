using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_4_Sem_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public float a, b, res;
        public char z;
        public bool znak = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += button1.Content;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox.Text += button2.Content;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            textBox.Text += button3.Content;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            textBox.Text += button4.Content;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            textBox.Text += button5.Content;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            textBox.Text += button6.Content;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            textBox.Text += button7.Content;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            textBox.Text += button8.Content;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            textBox.Text += button9.Content;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            textBox.Text += button10.Content;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            textBox.Text += ',';
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            b = float.Parse(textBox.Text);
            textBox.Clear();
            switch (z)
            {
                case '+':
                    res = a + b;
                    break;
                case '-':
                    res = a - b;
                    break;
                case '*':
                    res = a * b;
                    break;
                case '/':
                    res = a / b;
                    break;
                default:
                    break;
            }
            textBox.Text = res.ToString();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            a = float.Parse(textBox.Text);
            textBox.Clear();
            z = '+';
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            a = float.Parse(textBox.Text);
            textBox.Clear();
            z = '-';
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            a = float.Parse(textBox.Text);
            textBox.Clear();
            z = '*';
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            a = float.Parse(textBox.Text);
            textBox.Clear();
            z = '/';
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            if (znak == true)
            {
                textBox.Text = "-" + textBox.Text;
                znak = false;
            }
            else if (znak == false)
            {
                textBox.Text = textBox.Text.Replace("-", "");
                znak = true;
            }
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            textBox.Clear();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
