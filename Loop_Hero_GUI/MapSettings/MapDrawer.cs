using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Loop_Hero_GUI.Cards;
using Loop_Hero_GUI.Tiles;

namespace Loop_Hero_GUI.MapSettings
{
    partial class MapDrawer
    {
        public const int TILE_SIZE = 60;

        private readonly Maps _mapGenerator;

        private bool _mapEnd;

        private int _tileCount;

        public MapDrawer()
        {
            _mapGenerator = new();
            InGameMap = new Tile[Maps.ROWS, Maps.COLUMNS];
            RandomGen = new Random();
            StarterTile = new int[2];
        }

        public Random RandomGen { get; init; }

        public Tile[,] InGameMap { get; init; }

        public int[] StarterTile { get; set; }
        public List<Tile?>? CalculatedMap { get; set; }

        public int[]? GetStarterTile()
        {
            return StarterTile;
        }

        public void SetCampfire(int v)
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
                InGameMap[row, col].IsCardUsed = true;
                CalculatedMap?.Add(InGameMap[row, col]);
                StarterTile[0] = row * TILE_SIZE;
                StarterTile[1] = col * TILE_SIZE;
                GenerateCalculatedMap();
            }
        }

        private void GenerateCalculatedMap()
        {
            int index = 0;
            _mapEnd = false;
            while (!_mapEnd)
            {
                if (TileCheck(1, 0, index))
                {
                    index++;
                } else if (TileCheck(-1, 0, index))
                {
                    index++;
                } else if (TileCheck(0, 1, index))
                {
                    index++;
                } else if (TileCheck(0, -1, index))
                {
                    index++;
                }
            }
        }
        private bool TileCheck(int row, int col, int index)
        {
            Tile? temporaryTile = null;
            Tile? start = CalculatedMap?[index];
            try
            {
                if (InGameMap[start!.Row + row, start.Column + col] != null)
                {
                    temporaryTile = InGameMap[start.Row + row, start.Column + col];
                    if (temporaryTile == CalculatedMap?[0] && CalculatedMap.Count == _tileCount)
                    {
                        _mapEnd = true;
                    }
                }
                var tile = CalculatedMap?.Contains(temporaryTile);
                if (tile != null)
                {
                    CalculatedMap?.Add(temporaryTile);
                    return true;
                } else
                {
                    return false;
                }
            } catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
        public void FillMap(bool[,] map)
        {
            _tileCount = 0;
            for (int row = 0; row < map.GetLength(0); row++) 
            { 
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (!map[row, col])
                    {
                        InGameMap[row, col] = new RoadTile(row, col);
                        InGameMap[row, col].PositionX = col * TILE_SIZE;
                        InGameMap[row, col].PositionY = row * TILE_SIZE;
                        InGameMap[row, col].IsCardUsed = false;
                        _tileCount++;
                    }
                }
            }
        }
        public void DrawMap(DrawingContext dc)
        {
            for (int row = 0; row < InGameMap.GetLength(0); row++)
            {
                for (int col = 0; col < InGameMap.GetLength(1); col++) 
                {
                    if (InGameMap[row, col] != null)
                    {
                        InGameMap[row, col].DrawImage(dc);
                    }

                }
            }
        }

        public void ClickedCardDraw(DrawingContext dc)
        {
            //TODO 1.0 
        }

        public bool ForwardClickedCardToTile(Card card, int x, int y)
        {
            return true;
            //TODO 1.1
        }

        public void NovyDen(bool novyDen)
        {
            int NumberOfGeneratedEnemies = 0;
            for (int i = 0; i < CalculatedMap?.Count; i++)
            {
                Tile? tile = CalculatedMap[i];
                if (NumberOfGeneratedEnemies < 6)
                {
                    //TODO 1.2 NumberOfGeneratedEnemies += tile.novyDen(novyDen);
                }
                else
                {
                    //TODO 1.2.1 tile.updateEnemies(novyDen);
                }
            }
        }
    } 
}
