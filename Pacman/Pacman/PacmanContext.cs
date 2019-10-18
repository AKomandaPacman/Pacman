using Microsoft.EntityFrameworkCore;
using Pacman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman 
{
    public class PacmanContext : DbContext
    {
        public PacmanContext(DbContextOptions<PacmanContext> options) : base(options)
        {

        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}

