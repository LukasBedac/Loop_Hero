using Loop_Hero_GUI.Cards;
using Loop_Hero_GUI.Entity;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Loop_Hero_GUI.Tiles
{
    public abstract class Tile
    {
        public const int TILE_SIZE = 60;
        private BitmapImage? _image;
        private List<IEntity>? enemies;
        public Tile()
        {
            SetImage();
        }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }

        public Image? Image { get; set; }

        public Card? UsedCard { get; set; }

        public bool IsCardUsed { get; set; }

        public string? TileName { get; set; }

        public virtual void SetImage() => _image = new BitmapImage(new Uri("/Properties/tiles/RoadTile.png"));
        public void DrawImage(DrawingContext dc)
        {
            dc.DrawImage(_image, new Rect(PositionX, PositionY, TILE_SIZE, TILE_SIZE));
        }

        public abstract int NovyDen(bool novyDen);

        public abstract void UpdateEnemies(bool novyDen);

        public abstract void TileUsedCard(Card card);

        
    }
}