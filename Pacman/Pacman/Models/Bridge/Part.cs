using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models.Bridge
{
    public abstract class Part
    {
        public IColor _Icolor;
        public abstract void paint();

    }
}
