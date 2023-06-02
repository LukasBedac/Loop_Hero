using Loop_Hero_GUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace Loop_Hero_GUI.Cards
{
    internal class TreasureCard : Card
    {
        private BitmapImage? _image;

        private BitmapImage? _tileImage;
        public TreasureCard(int index) : base(index)
        {
            SetImage();
        }

        public TreasureCard() : base()
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
            return "Treasure";
        }

        public override List<IEntity> NewDay(List<IEntity> enemies)
        {
            if (enemies.Count < 1)
            {
                enemies.Add(new Zombie());
                return enemies;
            }
            return enemies;
        }

        public override void SetImage()
        {
            _image = new BitmapImage(new Uri("TreasureCard.png"));
            _tileImage = new BitmapImage(new Uri("Treasure.png"));
        }
    }
}
