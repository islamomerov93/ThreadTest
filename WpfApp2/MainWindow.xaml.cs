using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            VM.Lines = new ObservableCollection<string>();
            VM.DecryptedLines = new ObservableCollection<string>();
            DataContext = VM;
        }
        static ThreadStart threadStart;
        static Thread thread;
        static ThreadStart decryptedthreadStart;
        static Thread decryptedthread;
        private void Read_BtnClick(object sender, RoutedEventArgs e)
        {
            threadStart = new ThreadStart(ReadFromFile);
            thread = new Thread(threadStart);
            thread.Start();
        }
        [Obsolete]
        private void PauseResume_BtnClick(object sender, RoutedEventArgs e)
        {
            if (thread.IsAlive == true)
            {
                if (PR.Content.ToString() == "Pause")
                {
                    PR.Content = "Resume";
                    thread.Suspend();
                }
                else
                {
                    PR.Content = "Pause";
                    thread.Resume();
                }
            }
            else Console.WriteLine("Push read button");
        }

        private void Stop_BtnClick(object sender, RoutedEventArgs e)
        {
            thread.Abort();
        }

        private void Start_Encrypt_BtnClick(object sender, RoutedEventArgs e)
        {
            decryptedthreadStart = new ThreadStart(ReadFromFileForDecryption);
            decryptedthread = new Thread(decryptedthreadStart);
            decryptedthread.Start();
        }

        private void PauseResume_Encrypt_BtnClick(object sender, RoutedEventArgs e)
        {
            if (decryptedthread.IsAlive == true)
            {
                if (DePR.Content.ToString() == "Pause")
                {
                    DePR.Content = "Resume";
                    decryptedthread.Suspend();
                }
                else
                {
                    DePR.Content = "Pause";
                    decryptedthread.Resume();
                }
            }
            else Console.WriteLine("Push read button");
        }

        private void Stop_Encrypt_BtnClick(object sender, RoutedEventArgs e)
        {
            decryptedthread.Abort();
        }
        static void ReadFromFile()
        {
            if (!File.Exists(@"text.txt"))
            {
                for (int i = 0; i < 10000; i++)
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        VM.Lines.Add(StringCipher.Encrypt(i.ToString(),"Islam"));
                    });
                    Thread.Sleep(500);
                }
                File.WriteAllLines(@"text.txt", VM.Lines);
            }
            else
            {
                StreamReader reader = new StreamReader("text.txt");
                while ((reader.ReadLine()) != null)
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        VM.Lines.Add(reader.ReadLine());
                    });
                    Thread.Sleep(500);
                }
            }
        }
        static void ReadFromFileForDecryption()
        {
            for (int i = 0; i < VM.Lines.Count; i++)
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    VM.DecryptedLines.Add(StringCipher.Decrypt(VM.Lines[i],"Islam"));
                });
                Thread.Sleep(500);
            }
        }
    }
}
