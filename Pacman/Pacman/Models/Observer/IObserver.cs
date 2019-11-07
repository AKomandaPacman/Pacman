using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models.Observer
{
    public interface IObserver
    {
        void Update();
        int GetScore();
        string GetName();
    }
}
