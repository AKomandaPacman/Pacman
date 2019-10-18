using Pacman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Repository
{
    public interface IItemRepository : IRepository<Item>
    {
        //Task<List<Item>> GetWorkDayByIdAsync(int id);
    }
}
