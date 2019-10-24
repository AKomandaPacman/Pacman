using Pacman.Models.Builder.IBuilder;
using Pacman.Models.Factory;
using Pacman.Models.Product;
using Pacman.Models.Shared;
using Pacman.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Net.Http;

namespace Pacman.Models.Builder.ConcreteBuilder
{
    public class MapObjectsBuilder : IMapBuilder
    {
        MapObjects mapObjects = new MapObjects();
        private readonly IItemRepository _repository;

        public MapObjectsBuilder(IItemRepository repository)
        {
            _repository = repository;
        }

        public void AddPlayers(List<Player> players)
        {
            mapObjects.Players = players;
        }

        public void AddItems(List<Item> items)
        {
            mapObjects.Items = items;
        }

        public MapObjects GetObjects()
        {
            return mapObjects;
        }

        public void AddPlayer(Player player)
        {
            mapObjects.Players.Add(player);
        }

        public void AddItem(Item item)
        {
            mapObjects.Items.Add(item);
        }

        public void CreateRandomItem()
        {
            mapObjects.Items.Add(new ItemFactory().CreateRandomItem(null, null));
        }

        public void CreateItem(ItemType t, int x, int y)
        {
            Item item = new ItemFactory().CreateItem(t, x, y);
            mapObjects.Items.Add(item);
            //_repository.AddAsync(item);
        }
    }
}
