using Loop_Hero_GUI.Entity;
using Loop_Hero_GUI.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Loop_Hero_GUI.Cards
{
    public class CemeteryCard : Card
    {
        private BitmapImage? _image;

        private BitmapImage? _tileImage;
        public CemeteryCard(int index) : base(index)
        {
            SetImage();
        }

        public CemeteryCard() : base()
        {
            SetImage();
        }


        public override void DrawImage(DrawingContext dc)
        {
            dc.DrawImage(_image, new Rect(PositionX, PositionY, CARD_SIZEX, CARD_SIZEY));
        }

        public override void DrawTileImage(DrawingContext dc, int x, int y, int size)
        {
            dc.DrawImage(_tileImage, new Rect(x, y, size, size));
        }

        public override string GetCardName()
        {
            return "Cemetery";
        }

        public override List<IEntity> NewDay(List<IEntity> enemies)
        {
            if (enemies.Count < 3)
            {
                enemies.Add(new Ghost());
                return enemies;
            }
            return enemies;
        }

        public override void SetImage()
        {
            _image = new BitmapImage(new Uri("CemeteryCard.png"));
            _tileImage = new BitmapImage(new Uri("Cemetery.png"));
        }
    }
}
