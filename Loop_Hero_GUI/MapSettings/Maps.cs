using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop_Hero_GUI.MapSettings
{
    internal class Maps
    {

        public const int ROWS = 8;

        public const int COLUMNS = 16;

        public Maps()
        {
            RandomGen = new Random();
            MapBool = new bool[ROWS, COLUMNS];
            MapInt = new int[ROWS, COLUMNS];
            GenerateMap();
        }

        public Random RandomGen { get; init; }

        public bool[,] MapBool { get; set; }

        public int[,] MapInt { get; set; }

        public void GenerateMap()
        {
            int mapNumber = RandomGen.Next(1, 3);
            try
            {
                using StreamReader? map = new("Mapa" + mapNumber + ".txt");
                int row = 0;
                int col = 0;
                while (col < COLUMNS && row < ROWS)
                {
                    string? line = map?.ReadLine();
                    while (col < COLUMNS)
                    {
                        if (line != null)
                        {
                            string[] tempArray = line.Split(" ");
                            int mapNumbers = int.Parse(tempArray[col]);
                            MapInt[row, col] = mapNumbers;
                            col++;
                        }
                        else
                        {
                            return;
                        }
                    }
                    if (col == COLUMNS)
                    {
                        col = 0;
                        row++;
                    }
                    map?.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}, error while reading input map file!");
            }
        }

        public void BooleanMapTransfer()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    if (MapInt[i, j] == 1)
                    {
                        MapBool[i, j] = true;
                    }
                }
            }
        }
    }
}
