using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models.Bridge
{
    public class Wall : Part
    {
        private string color;

        public string GetColor()
        {
            return this.color;
        }

        public override void paint()
        {
            /* manau kazkaip reik priskirt wall klase fronto vietai kur kuriamos sienos
             * o paskui kvieciant Type klases metoda paintWallBlack ar kita ir
             * pagal ideja turetu pasikeist spalva 
             */
            this.color = _Icolor.setColor();

        }
    }
}
