using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models.Prototype
{
    interface IGhostPrototype
    {
        GhostPrototype Copy();
        GhostPrototype DeepCopy();
    }
}