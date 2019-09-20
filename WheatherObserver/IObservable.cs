using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheatherObserver
{
    public interface IObservable
    {
        void Add(IObserver ob);
        void Remove(IObserver ob);
        void Notify();
    }
}
