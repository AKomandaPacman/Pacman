using Pacman.Models.Decorator;
using Pacman.Models.Observer;
using Pacman.Models.Shared;
using System;

namespace Pacman.Models
{
    public class Player : Entity, IObserver, IDisplays
    {
        public string name { get; set; }
        public int score { get; set; }
        public double posX { get; set; }
        public double posY { get; set; }
        public bool boosted { get; set; }
        public bool ghost { get; set; }
        public string image { get; set; }

        public string GetName()
        {
            return name;
        }

        public int GetScore()
        {
            return score;
        }

        public void Update(string name, int score)
        {
            //Change leading player here when score board is implemented
            throw new NotImplementedException();
        }
        //public int? skinId { get; set; }

        public string GetImage()
        {
            PlayerDisplay dImage = new PlayerDisplay();
            this.image = dImage.GetImage();
            return this.image;

        }
    }
}
