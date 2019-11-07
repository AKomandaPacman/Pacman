using Pacman.Models.Decorator;
using Pacman.Models.Observer;
using Pacman.Models.Shared;
using System.Data.SqlClient;
using System;

namespace Pacman.Models
{
    public class Player : Entity, IObserver, IDisplays
    {
        public string name { get; set; }
        public int score { get; set; }
        public double posX { get; set; }
        public double posY { get; set; }
        public bool boosted { get; set; }
        public bool ghost { get; set; }
        public string image { get; set; }
        //public int? skinId { get; set; }


        public string GetName()
        {
            return name;
        }

        public int GetScore()
        {
            return score;
        }

        public void Update()
        {
            string connetionString;
            SqlConnection conn;

            connetionString = @"Server=(localdb)\\MSSQLLocalDB;Database=PacmanDB;Trusted_Connection=True;MultipleActiveResultSets=true";

            conn = new SqlConnection(connetionString);
            conn.Open();

            string query = "UPDATE Player SET score = @pS, posX = @pX, posY = @pY, boosted = @pB, image = @pI, ghost = @pH WHERE name = @pN";
            //string query = "set Where [dbo].[Items]([LastUpdated],[type],[posX],[posY])VALUES(@pLU, @pT, @pX, @pY);";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@pN", name);
            cmd.Parameters.AddWithValue("@pS", score);
            cmd.Parameters.AddWithValue("@pX", posX);
            cmd.Parameters.AddWithValue("@pY", posY);
            cmd.Parameters.AddWithValue("@pB", boosted);
            cmd.Parameters.AddWithValue("@pI", image);
            cmd.Parameters.AddWithValue("@pH", ghost);
            cmd.ExecuteNonQueryAsync();

            conn.Close();
        }

        public string GetImage()
        {
            PlayerDisplay dImage = new PlayerDisplay();
            this.image = dImage.GetImage();
            return this.image;

        }
    }
}
