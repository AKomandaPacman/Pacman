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

        public override Item CreateRandomItem(object x, object y)
        {
            Random random = new Random(Math.Abs(Guid.NewGuid().GetHashCode()));
            int posX, posY;
            if (x == (null) || y == (null))
            {
                posX = random.Next(100);
                posY = random.Next(100);
            }
            else { posX = (int)x; posY = (int)y; }
            
            var type = random.Next(5);

            Item item = new Item
            {
                Id = 1,
                LastUpdated = DateTime.Now,
                type = (ItemType)random.Next(Enum.GetValues(typeof(ItemType)).Cast<ItemType>().Count()),
                posX = posX,
                posY = posY
            };

            Logger.GetLogger().Log($"Created PowerUp {item.type}.");

            PostToDB(item); // saves kreated item to db

            return item;
        }

        public override Item CreateItem(ItemType t, int x, int y)
        {
            Item item = new Item
            {
                Id = 1,
                LastUpdated = DateTime.Now,
                type = t,
                posX = x,
                posY = y
            };

            Logger.GetLogger().Log($"Created {item.type}.");

            PostToDB(item); // saves kreated item to db

            return item;
        }

        private void PostToDB(Item item)
        {
            string connetionString;
            SqlConnection conn;

            connetionString = "Server=(localdb)\\MSSQLLocalDB;Database=PacmanDB;Trusted_Connection=True;MultipleActiveResultSets=true";

            conn = new SqlConnection(connetionString);
            conn.Open();

            string query = "INSERT INTO [dbo].[Items]([LastUpdated],[type],[posX],[posY])VALUES(@pLU, @pT, @pX, @pY);";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@pLU", item.LastUpdated);
            cmd.Parameters.AddWithValue("@pT", item.type);
            cmd.Parameters.AddWithValue("@pX", item.posX);
            cmd.Parameters.AddWithValue("@pY", item.posY);
            cmd.ExecuteScalar();

            conn.Close();
        }
    }
}
