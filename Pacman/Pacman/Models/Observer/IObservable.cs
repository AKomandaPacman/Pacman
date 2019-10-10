using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models.Observer
{
    interface IObservable
    {
        void Add(IObserver observer);
        void Remove(IObserver observer);
        void Notify();
    }
}
