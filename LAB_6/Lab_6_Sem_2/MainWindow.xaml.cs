using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_6_Sem_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = Mouse.GetPosition(this);
            Thickness marginThickness = button1.Margin;
            if ((pos.X >= marginThickness.Left - 10) && (pos.X <= marginThickness.Right + 10))
            {
                if (pos.X >= marginThickness.Right)
                {
                    marginThickness.Left -= 5;
                }
                else marginThickness.Left += 5;
                if (button1.Width != 0) button1.Width -= 1;
                if(button1.Height != 0) button1.Height -= 1;
            }
            if ((pos.Y >= marginThickness.Top - 10) && (pos.Y <= marginThickness.Bottom + 10))
            {
                if (pos.Y >= marginThickness.Bottom)
                {
                    marginThickness.Top -= 5;
                }
                else marginThickness.Top += 5;

                if (button1.Width != 0) button1.Width -= 1;
                if (button1.Height != 0) button1.Height -= 1;
            }
            if (button1.Width - Width / 2 < 0)
            {
                marginThickness.Left = 50;
            }
            if ((button1.Width - Width / 2 + button1.Width) > window.Width)
            { marginThickness.Left = window.Width - button1.Width; }
            if (button1.Height-(Height/2) < 0)
            {
                marginThickness.Top = 50;
            }
            if ((button1.Height-(Height/2) + button1.Height) > window.Height)
            { marginThickness.Top = window.Height - button1.Height; }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            while (i != 8)
            {
                this.Title = "Press OK!";
                i++;
            }
            if (button1.Width <= 0 || button1.Height <= 0)
            {
                this.Title = "You will never press OK!";
            }
        }
    }
}
