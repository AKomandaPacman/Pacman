using Pacman.Models.Singleton;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace Pacman.Models.Factory
{
    public abstract class Factory
    {
        public Item CreateRandomItem()
        {
            Random random = new Random(Math.Abs(Guid.NewGuid().GetHashCode()));
            var posX = random.Next(100);
            var posY = random.Next(100);
            var type = random.Next(10);

            Item item = new Item
            {
                type = type,
                posX = posX,
                posY = posY
            };

            Logger.GetLogger().Log($"Created PowerUp {item.type}");
            

            //try
            //{
            //    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString))
            //    {
            //        using (var cmd = new SqlCommand("dbo.Items", conn))
            //        {
            //            cmd.CommandType = CommandType.StoredProcedure;

            //            SqlParameter parameterType = new SqlParameter("@type", SqlDbType.Int, 50);
            //            SqlParameter parameterPosX = new SqlParameter("@posX", SqlDbType.Float, 50);
            //            SqlParameter parameterPosY = new SqlParameter("@posY", SqlDbType.Float, 50);

            //            parameterType.Value = type;
            //            parameterPosX.Value = posX;
            //            parameterPosY.Value = posY;

            //            cmd.Parameters.Add(parameterType);
            //            cmd.Parameters.Add(parameterPosX);
            //            cmd.Parameters.Add(parameterPosY);

            //            conn.Open();
            //            cmd.ExecuteNonQuery();
            //            conn.Close();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            return item;
        }

        public Item CreateBiggerFood()
        {
            throw new NotImplementedException();
        }

        public Item CreateTeleportation()
        {
            throw new NotImplementedException();
        }

        public Item CreateBullet()
        {
            throw new NotImplementedException();
        }

        public Item CreateSpeed()
        {
            throw new NotImplementedException();
        }
    }
}
