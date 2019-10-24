using Pacman.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pacman.Models.Product;

namespace Pacman.Models.Builder.IBuilder
{
    interface IMapBuilder
    {
        void AddPlayers(List<Player> players);
        void AddPlayer(Player player);
        void AddItems(List<Item> items);
        void AddItem(Item item);
        void CreateRandomItem();
        void CreateItem(ItemType t, int x, int y);
        MapObjects GetObjects();
    }
}
