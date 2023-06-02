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
        public virtual int PositionX { get; set; }

        public virtual int PositionY { get; set; }

        public virtual int Row { get; set; }

        public virtual int Column { get; set; }

        public virtual Card? UsedCard { get; set; }

        public virtual bool IsCardUsed { get; set; }

        public virtual string? TileName { get; set; }

        public virtual List<IEntity>? Enemies { get => enemies; set => enemies = value; }

        public virtual void SetImage() => _image = new BitmapImage(new Uri("RoadTile.png"));

        public virtual void DrawImage(DrawingContext dc)
        {
            dc.DrawImage(_image, new Rect(PositionX, PositionY, TILE_SIZE, TILE_SIZE));
        }

        public abstract int NewDay(bool newDay);

        public abstract void UpdateEnemies(bool newDay);

        public abstract void TileUsedCard(Card card);

        
    }
}