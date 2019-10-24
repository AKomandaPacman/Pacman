using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models.Factory
{
    public abstract class Factory
    {
        public abstract Item CreateRandomItem(object x, object y);
        public abstract Item CreateItem(ItemType t, int x, int y);
    }
}
