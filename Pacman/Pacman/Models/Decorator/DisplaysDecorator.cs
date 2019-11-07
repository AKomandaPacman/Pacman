using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Pacman.Models.Decorator
{
    public abstract class DisplaysDecorator : IDisplays
    {
        string image;
        public abstract string GetImage();
    }
}
