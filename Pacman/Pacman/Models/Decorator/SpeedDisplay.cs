﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models.Decorator
{
    public class SpeedDisplay : DisplaysDecorator
    {
        public override string GetImage()
        {
            return @"assets/powerup.png";
        }
    }
}
