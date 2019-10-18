using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Repository
{
    public class ItemRepository : Repository<Models.Item>, IItemRepository
    {
        public ItemRepository(PacmanContext context) : base(context)
        {
        }

        //Užklausos pvz
        //public async Task<List<Models.Item>> GetItemByIdAsync(int id)
        //{
        //    return await Task.FromResult(DbSet.Where(x => x.Id == id).ToList());
        //}
    }
}
