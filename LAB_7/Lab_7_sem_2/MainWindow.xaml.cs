using System;
using System.IO;
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

namespace Lab_7_sem_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string path = @"C:\Folder\Folder";
        static string path_2 = @"";
        static string path_3 = @"C:\Folder";
        public MainWindow()
        {
            InitializeComponent();       
            MessageBox.Show($"Your path: {path}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                path = @"C:\Folder\Folder" + i.ToString();
                if (!dir.Exists)
                {
                    dir.Create();
                }
            }
            path = @"C:\Folder\Folder";
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                path = @"C:\Folder\Folder" + i.ToString();
                if (dir.Exists)
                {
                    dir.Delete();
                }
            }
            path = @"C:\Folder\Folder";
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 4674; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                path += @"\Folder";
                if (!dir.Exists)
                {
                    dir.Create();
                }
            }
            MessageBox.Show($"Max of created folders = 4675");
            path = @"C:\Folder\Folder";
        }
        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            foreach (string folder in Directory.GetDirectories(path))
            {
                Directory.Delete(folder, true);
            }
            DirectoryInfo dir = new DirectoryInfo(path);
            dir.Delete();
        }

        private void btn_5_Click(object sender, RoutedEventArgs e)
        {
            if (tb_1.Text != null)
            {
                path_2 += tb_1.Text;
            }
            FindFiles(new DirectoryInfo(path_2));
        }
        void FindFiles(DirectoryInfo path)
        {
            try
            {
                foreach (FileInfo f in path.GetFiles("*.txt"))
                    lstb_1.Items.Add(f.FullName);
            }
            catch (Exception) { }

            foreach (DirectoryInfo dir in path.GetDirectories())
            {
                FindFiles(dir);
            }
        }

        private void lstb_1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (tb_1.Text != null)
            {
                path_2 += tb_1.Text;
            }
            ReadFiles(new DirectoryInfo(path_2));
        }
        void ReadFiles(DirectoryInfo path)
        {
            lstb_1.Items.Clear();
            using (FileStream fstream = File.OpenRead($"{path_3}\\Folder.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                lstb_1.Items.Add(textFromFile);
            }
        }
    }
}
