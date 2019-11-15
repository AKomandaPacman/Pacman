using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pacman.Models.Factory;


namespace Pacman.Models.Builder
{
    public class Start
    {
        public void main()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1, 3);
            int mapNumber = randomNumber;
            var fileName = @"..\Pacman\ClientApp\src\assets\maps\map" + mapNumber.ToString() + ".txt";
            string[] lines = System.IO.File.ReadAllLines(fileName);

            int[,] map = new int[100, 100];
            int n = 0, m = 0, count = 0, tmpn = 0, tmpm = 0;
            foreach (string line in lines)
            {
                if(count == 0)
                {
                    var colss = line.Split(':');
                    tmpn = Int32.Parse(colss[0]);
                    tmpm = Int32.Parse(colss[1]);
                }
                else
                {
                    var cols = line.Split(',');
                    foreach(var col in cols)
                    {
                        map[n, m] = Int32.Parse(col);
                        n++;
                    }
                    n = 0;
                    m++;
                }
                count++;
            }

            int[] AvailableX = new int[1000];
            int[] AvailableY = new int[1000];
            int yStart = 0;
            int xStart = 0;
            int size = 0;
            for (int i = 0; i < tmpn; i++)
            {
                for(int j = 0; j < tmpm; j++)
                {
                    if (map[i,j] == 0)
                    {
                        xStart = i * 20;
                        yStart = j * 20;

                        AvailableX[size] = xStart;
                        AvailableY[size++] = yStart;
                    }
                }
            }

            ItemFactory factory = new ItemFactory();

            for (int i = 0; i < 1000; i++)
            {
                if (AvailableX[i] != 0)
                {
                    //factory.CreateItem(0, AvailableX[i], AvailableY[i]);
                }
            }

            Random random = new Random();

            yStart = 0;
            xStart = 0;
            var yEnd = yStart + 20 / 2 + (int)Math.Floor((decimal)7 / 2); // maistui
            var xEnd = xStart + 20 / 2;

            


            //5 random foodai
            for(int i =0;i<5;i++)
            {
                var posY = random.Next(yStart, yEnd);
                var posX = random.Next(xStart, xEnd);
                //factory.CreateItem(0, posX, posY);
            }
        }
       
    }
}
