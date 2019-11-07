using System;
using System.Collections.Generic;
using System.Text;

namespace Pacman.Models.Observer
{
    class Observable : IObservable
    {
        private List<IObserver> players = new List<IObserver>();
        public void Add(IObserver observer)
        {
            players.Add(observer);
        }

        public void Notify()
        {
            foreach (var player in players)
            {
                player.Update();
            }
        }

        public void Remove(IObserver observer)
        {
            players.Remove(observer);
        }
    }
}
