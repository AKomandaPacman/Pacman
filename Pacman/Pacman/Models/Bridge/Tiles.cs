using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models.Bridge
{
    public class Tiles : Part
    {
        private string color;

        public string GetColor()
        {
            return this.color;
        }

        public override void paint()
        {
            this.color = _Icolor.setColor();

        }
    }
}
