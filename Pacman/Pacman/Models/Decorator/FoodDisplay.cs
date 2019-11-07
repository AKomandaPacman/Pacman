using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models.Decorator
{
    public class FoodDisplay : DisplaysDecorator
    {
        public override string GetImage()
        {
            return @"..\Pacman\ClientApp\src\assets\food.png";
        }
    }
}
