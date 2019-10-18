using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models
{
    public enum ItemType
    {
        [Display(Name = "Food")]
        food,

        [Display(Name = "Bigger food")]
        biggerFood,

        [Display(Name = "Speed")]
        speed,

        [Display(Name = "Bullet")]
        bullet,

        [Display(Name = "Teleportation")]
        teleportation,
    }
}
