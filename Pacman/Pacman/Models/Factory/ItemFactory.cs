using Pacman.Models.Singleton;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using Pacman.Controllers;

namespace Pacman.Models.Factory
{
    public class ItemFactory : Factory
    {

        public override Item CreateRandomItem()
        {
            Random random = new Random(Math.Abs(Guid.NewGuid().GetHashCode()));
            var posX = random.Next(100);
            var posY = random.Next(100);
            var type = random.Next(5);

            Item item = new Item
            {
                type = (ItemType)random.Next(Enum.GetValues(typeof(ItemType)).Cast<ItemType>().Count()),
                posX = posX,
                posY = posY
            };

            Logger.GetLogger().Log($"Created PowerUp {item.type}");

            return item;
        }

        public override Item CreateFood(int x, int y)
        {
            Item item = new Item
            {
                type = ItemType.food,
                posX = x,
                posY = y
            };

            Logger.GetLogger().Log($"Created {item.type}");

            return item;
        }

        public override Item CreateBiggerFood(int x, int y)
        {
            Item item = new Item
            {
                type = ItemType.biggerFood,
                posX = x,
                posY = y
            };

            Logger.GetLogger().Log($"Created {item.type}");

            return item;
        }

        public override Item CreateTeleportation(int x, int y)
        {
            Item item = new Item
            {
                type = ItemType.teleportation,
                posX = x,
                posY = y
            };

            Logger.GetLogger().Log($"Created PowerUp {item.type}");

            return item;
        }

        public override Item CreateBullet(int x, int y)
        {
            Item item = new Item
            {
                type = ItemType.bullet,
                posX = x,
                posY = y
            };

            Logger.GetLogger().Log($"Created PowerUp {item.type}");

            return item;
        }

        public override Item CreateSpeed(int x, int y)
        {
            Item item = new Item
            {
                type = ItemType.speed,
                posX = x,
                posY = y
            };

            Logger.GetLogger().Log($"Created PowerUp {item.type}");

            return item;
        }
    }
}
