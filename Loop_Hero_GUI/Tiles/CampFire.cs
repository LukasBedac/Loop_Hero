using Loop_Hero_GUI.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Loop_Hero_GUI.Tiles
{
    public class CampFire : Tile
    {
        private BitmapImage? _image;
        public CampFire(int row, int col) 
        { 
            base.Row = row;
            base.Column = col;
            SetImage();
        }

        public override int NewDay(bool novyDen)
        {
            return 0;
        }

        public override void TileUsedCard(Card card)
        {
            
        }

        public override void UpdateEnemies(bool novyDen)
        {
            
        }

        public override void SetImage()
        {
            _image = new BitmapImage(new Uri("/Properties/tiles/CampFire.png"));
        }

        public override void DrawImage(DrawingContext dc)
        {
            dc.DrawImage(_image, new Rect(PositionX, PositionY, TILE_SIZE, TILE_SIZE));
        }
    }
}
