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

        ObservableCollection<string> lines;

        public VM()
        {
            this.lines = new ObservableCollection<string>();
            this.Lines = new ObservableCollection<string>();
        }

        public ObservableCollection<string> Lines {
            get
            {
                return lines;
            }
            set
            {
                lines = value;
                OnPropertyChanged("Lines");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(p)));
        }
    }
}
