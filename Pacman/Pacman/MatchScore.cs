using Pacman.Models.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman
{
    public class MatchScore : IObservable
    {
        public int Id { get; set; }
        public List<IObserver> Observers { get; set; } = new List<IObserver>();

        public void Add(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void Notify()
        {
            IObserver first = Observers.OrderByDescending(x => x.GetScore()).First();
            foreach (IObserver observer in Observers)
            {
                observer.Update(first.GetName(), first.GetScore());
            }
        }

       
    }
}
