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
            mapObjects.players = players;
        }

        public void AddItems(List<Item> items)
        {
            mapObjects.items = items;
        }

        public MapObjects GetObjects()
        {
            return mapObjects;
        }

        public void AddPlayer(Player player)
        {
            mapObjects.players.Add(player);
        }

        public void AddItem(Item item)
        {
            mapObjects.items.Add(item);
        }

        public void CreateRandomItem()
        {
            mapObjects.items.Add(new ItemFactory().CreateRandomItem());
        }

        public void CreateFood(int x, int y)
        {
            Item item = new ItemFactory().CreateFood(x, y);
            mapObjects.items.Add(item);
            //_repository.AddAsync(item);
        }

        public void CreateBiggerFood(int x, int y)
        {
            mapObjects.items.Add(new ItemFactory().CreateBiggerFood(x, y));
        }

        public void CreateTeleportation(int x, int y)
        {
            mapObjects.items.Add(new ItemFactory().CreateTeleportation(x, y));
        }

        public void CreateBullet(int x, int y)
        {
            mapObjects.items.Add(new ItemFactory().CreateBullet(x, y));
        }

        public void CreateSpeed(int x, int y)
        {
            mapObjects.items.Add(new ItemFactory().CreateSpeed(x, y));
        }
    }
}
