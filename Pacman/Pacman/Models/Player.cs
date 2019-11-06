using Pacman.Models.Shared;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacman.Models
{
    public class Player : Entity
    {
        public string name { get; set; }
        public int score { get; set; }
        public double posX { get; set; }
        public double posY { get; set; }
        public int item { get; set; }
        public bool ghost { get; set; }

        public string GetName()
        {
            return name;
        }

        public int GetScore()
        {
            return score;
        }

        public void Update(string name, int score)
        {
            string connetionString;
            SqlConnection conn;

            connetionString = @"Server=(localdb)\\MSSQLLocalDB;Database=PacmanDB;Trusted_Connection=True;MultipleActiveResultSets=true";

            conn = new SqlConnection(connetionString);
            conn.Open();

            string query = "UPDATE Player SET score = @pS, posX = @pX, posY = @pY, item = @pI, ghost = @pH WHERE name = @pN";
            //string query = "set Where [dbo].[Items]([LastUpdated],[type],[posX],[posY])VALUES(@pLU, @pT, @pX, @pY);";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@pN", name);
            cmd.Parameters.AddWithValue("@pS", score);
            cmd.Parameters.AddWithValue("@pX", posX);
            cmd.Parameters.AddWithValue("@pY", posY);
            cmd.Parameters.AddWithValue("@pI", item);
            cmd.Parameters.AddWithValue("@pH", ghost);
            cmd.ExecuteNonQueryAsync();

            conn.Close();
        }
        //public int? skinId { get; set; }
    }
}
