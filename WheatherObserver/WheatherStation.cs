using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing;

namespace WheatherObserver
{
    public class WheatherStation : IObservable
    {
         WheatherState[] states = new WheatherState[] {new WheatherState {WheatherType = "Sunny", WheatherImagePath = "1.jpg"},
         new WheatherState {WheatherType = "Claudy", WheatherImagePath = "2.jpg"},
            new WheatherState {WheatherType = "Snow", WheatherImagePath = "3.jpg"},
         new WheatherState {WheatherType = "Rain", WheatherImagePath = "4.jpg"},
            new WheatherState {WheatherType = "Wind", WheatherImagePath = "5.jpg"}};

        List<IObserver> observers = new List<IObserver>();
        Timer timer;
        static object locker = new object();
        public WheatherStation()
        {

        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (locker)
            {
                Notify();
            }
        }
        public void Add(IObserver ob)
        {
            if (timer == null)
            {
                timer = new Timer();
                timer.Interval = 1000;
                timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                timer.Enabled = true;
            }
            observers.Add(ob);
            //System.Windows.MessageBox.Show("Add: " + observers.Count);
        }

        void dtimer_Tick(object sender, EventArgs e)
        {
            Notify();
        }

        public void Remove(IObserver ob)
        {
            observers.Remove(ob);
            //System.Windows.MessageBox.Show("Remove: " + observers.Count);
            if (observers.Count == 0)
            {
                timer.Stop();
                timer.Dispose();
                //System.Windows.MessageBox.Show("timers stays 0");
            }
        }
        public void Notify()
        {
            foreach (IObserver ob in observers)
                ob.Update();
        }

        public WheatherState GetState()
        {
            WheatherState state = new WheatherState();
            Random rand = new Random();
            int index = rand.Next(0, (states.Length - 1));
            states[index].Temperature = rand.Next(-30, 30);
            return states[index];
        }
    }
}
