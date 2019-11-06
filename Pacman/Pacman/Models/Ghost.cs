using Pacman.Models.Prototype;
using Pacman.Models.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models
{
    public class Ghost : GhostPrototype
    {
        public Ghost(double x, double y) : base (x, y)
        {

        }

        public override GhostPrototype Copy()
        {
            Logger.GetLogger().Log($"Created shallow copy of ghost");
            return this.MemberwiseClone() as GhostPrototype;
        }

        public override GhostPrototype DeepCopy()
        {
            Logger.GetLogger().Log($"Created copy of ghost");
            GhostPrototype ghost = this.MemberwiseClone() as GhostPrototype;
            double x = ghost.getXCoordinate();
            double y = ghost.getYCoordinate();
            ghost.setXCoordinate(x);
            ghost.setYCoordinate(y);
            return ghost;
        }
    }
}
