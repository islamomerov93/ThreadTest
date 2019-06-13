using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static VM VM = new VM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = VM;
        }
        static List<string> lines;
        static string line;
        static StreamReader file;
        ThreadStart ts;
        Thread t;
        private void Read_BtnClick(object sender, RoutedEventArgs e)
        {
            ts = new ThreadStart(Method);
            t = new Thread(ts);
            t.Start();
        }

        private void PauseResume_BtnClick(object sender, RoutedEventArgs e)
        {

        }

        private void Stop_BtnClick(object sender, RoutedEventArgs e)
        {

        }

        private void Start_Encrypt_BtnClick(object sender, RoutedEventArgs e)
        {

        }

        private void PauseResume_Encrypt_BtnClick(object sender, RoutedEventArgs e)
        {

        }

        private void Stop_Encrypt_BtnClick(object sender, RoutedEventArgs e)
        {

        }
        static void Method()
        {
            file = new StreamReader(@"test.txt");
            while ((line = file.ReadLine()) != null)
                VM.Lines.Add(line);
            file.Close();
        }
    }
}
