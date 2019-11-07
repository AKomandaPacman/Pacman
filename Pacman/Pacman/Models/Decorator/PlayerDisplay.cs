namespace Pacman.Models.Decorator
{
    public class PlayerDisplay : DisplaysDecorator
    {
        public override string GetImage()
        {
            return @"assets/p_yellow.png";
        }
    }
}
