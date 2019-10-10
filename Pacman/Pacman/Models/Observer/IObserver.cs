using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models.Observer
{
    public interface IObserver
    {
        void Update(string name, int score);

        int GetScore();
        string GetName();
    }
}
