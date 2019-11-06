using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models.Prototype
{
    public abstract class GhostPrototype : IGhostPrototype
    {
        private string id { get; set; } = "Enemy";
        private double posX { get; set; } = 0;
        private double posY { get; set; } = 0;

        protected GhostPrototype(double x, double y)
        {
            posX = x;
            posY = y;
        }

        public void setXCoordinate(double x)
        {
            posX = x;
        }

        public void setYCoordinate( double y)
        {
            posY = y;
        }

        public double getXCoordinate()
        {
            return posX;
        }

        public double getYCoordinate()
        {
            return posY;
        }

        public abstract GhostPrototype Copy();
        public abstract GhostPrototype DeepCopy();

        public string GetId()
        {
            return id;
        }
    }
}
