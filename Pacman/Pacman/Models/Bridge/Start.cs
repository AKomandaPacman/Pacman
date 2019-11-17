using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models.Bridge
{
    public class Start
    { 
        public void PaintWallBlack()
        {
            Part part = new Wall();

            //paints wall in black
            part._Icolor = new Black();
            part.paint();
        }

        public void PaintWallDarkBlue()
        {
            Part part = new Wall();

            //paints wall in dark blue
            part._Icolor = new DarkBlue();
            part.paint();

        }

    }
}
