using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class VM : INotifyPropertyChanged
    {

        

        public VM()
        {
            this.lines = new ObservableCollection<string>();
            this.Lines = new ObservableCollection<string>();
        }
        ObservableCollection<string> lines;
        public ObservableCollection<string> Lines {
            get
            {
                return lines;
            }
            set
            {
                lines = value;
                OnPropertyChanged(nameof(Lines));
            }
        }
        ObservableCollection<string> decryptedlines;
        public ObservableCollection<string> DecryptedLines
        {
            get
            {
                return decryptedlines;
            }
            set
            {
                decryptedlines = value;
                OnPropertyChanged(nameof(DecryptedLines));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(p));
        }
    }
}
