using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models.Factory
{
    public abstract class Factory
    {
        public abstract Item CreateRandomItem();
        public abstract Item CreateFood(int x, int y);
        public abstract Item CreateBiggerFood(int x, int y);
        public abstract Item CreateTeleportation(int x, int y);
        public abstract Item CreateBullet(int x, int y);
        public abstract Item CreateSpeed(int x, int y);
    }
}
