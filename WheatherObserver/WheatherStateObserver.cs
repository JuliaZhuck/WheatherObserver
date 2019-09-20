using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WheatherObserver
{
    public class WheatherStateObserver : IObserver, INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        WheatherStation station;
        WheatherState state;


        public WheatherStateObserver(WheatherStation station)
        {
            this.station = station;
            station.Add(this);
        }

        protected void SetImageDate()
        {
            if (state == null)
                state = station.GetState();
            BitmapImage img = new BitmapImage();

            img.BeginInit();
            img.CacheOption = BitmapCacheOption.OnLoad;
            img.UriSource = new Uri("pack://application:,,,/res/" + state.WheatherImagePath);
            //new Uri(@"/ObserverPattern;component/res/" + state.Path, UriKind.Relative);
            img.EndInit();
            img.Freeze();
            WheatherImage = img;
        }

        ImageSource wheatherImage;
        public ImageSource WheatherImage
        {
            get { return wheatherImage; }
            set
            {
                wheatherImage = value;
                OnPropertyChanged("WheatherImage");
            }
        }

        string temperature;
        public string Temperature
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
            set
            {
                wheatherType = value;
                OnPropertyChanged("WheatherType");
            }
        }

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public void Update()
        {
            state = station.GetState();
            SetImageDate();
            Temperature = state.Temperature + "°C";
            WheatherType = state.WheatherType;
        }

        public void Dispose()
        {
            station.Remove(this);
        }
    }
}
