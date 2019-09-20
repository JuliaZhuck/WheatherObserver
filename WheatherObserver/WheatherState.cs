using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WheatherObserver
{
   public class WheatherState : INotifyPropertyChanged
    {
        private int temperature;
  
        public int Temperature
        {
            get { return temperature; }
            set
            {
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }
        string wheatherType;
        public string WheatherType
        {
            get { return wheatherType; }
            set { wheatherType = value;
                OnPropertyChanged("WheatherType");
            }
        }
        string wheatherImagePath;
        public string WheatherImagePath
        {
            get { return wheatherImagePath; }
            set { wheatherImagePath = value;
                OnPropertyChanged("WheatherImagePath");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //public void OnPropertyChanged([CallerMemberName]string prop = "")
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
