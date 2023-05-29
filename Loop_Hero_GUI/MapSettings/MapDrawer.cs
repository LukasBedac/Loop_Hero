using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using Loop_Hero_GUI.Tiles;

namespace Loop_Hero_GUI.MapSettings
{
    internal class MapDrawer
    {
        public const int TILE_SIZE = 60;

        private readonly Maps _mapGenerator;

        private bool _mapEnd;

        public MapDrawer()
        {
            _mapEnd = false;
            _mapGenerator = new();
            InGameMap = new Tile[Maps.ROWS, Maps.COLUMNS];
            RandomGen = new Random();
        }

        public Random RandomGen { get; init; }

        public Tile[,] InGameMap { get; init; }

        public int[]? StarterTile { get; set; }
        public List<Tile>? CalculatedMap { get; set; }

        public void SetCampfire()
        {
            int row = RandomGen.Next(Maps.ROWS);
            int col = RandomGen.Next(Maps.COLUMNS);
            while (InGameMap[row, col] == null)
            {
                row = RandomGen.Next(Maps.ROWS);
                col = RandomGen.Next(Maps.COLUMNS);
            }
            if (InGameMap[row, col] != null)
            {
                InGameMap[row, col] = new CampFire(row, col);
                InGameMap[row, col].PositionX = col * TILE_SIZE;
                InGameMap[row, col].PositionY = row * TILE_SIZE;
                InGameMap[row, col].UsedCard = true;
                CalculatedMap?.Add(InGameMap[row, col]);
            }
        }

    }
}
