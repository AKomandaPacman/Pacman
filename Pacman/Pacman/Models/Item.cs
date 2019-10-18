using Pacman.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models
{
    public class Item : Entity
    {
        public ItemType type { get; set; }
        public double posX { get; set; }
        public double posY { get; set; }

        //public string icon { get; set; }

        //public string GetIcon()
        //{
        //    return icon;
        //}
    }
}
