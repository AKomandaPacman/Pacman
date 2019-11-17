using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models.Bridge
{
    public class Black : IColor
    {
        public string setColor()
        {
            return "#000103";
        }
    }
}
