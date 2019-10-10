using Pacman.Models.Observer;
using Pacman.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models
{
    public class Player : Entity, IObserver
    {
        public string name { get; set; }
        public int score { get; set; }
        public double posX { get; set; }
        public double posY { get; set; }
        public bool boosted { get; set; }
        public bool ghost { get; set; }

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
    }
}
