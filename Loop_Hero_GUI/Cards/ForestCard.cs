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
    public class ForestCard : Card
    {
        private BitmapImage? _image;

        private BitmapImage? _tileImage;
        public ForestCard(int index) : base(index)
        {
            SetImage();
        }

        public ForestCard() : base()
        {
            SetImage();
        }


        public override void DrawImage(DrawingContext dc)
        {
            dc.DrawImage(_image, new Rect(PositionX, PositionY, CARD_SIZEX, CARD_SIZEY));
        }

        public override void DrawTIleImage(DrawingContext dc, int x, int y, int size)
        {
            dc.DrawImage(_tileImage, new Rect(x, y, size, size));
        }

        public override string GetCardName()
        {
            return "Forest";
        }

        public override List<IEntity> NewDay(List<IEntity> enemies)
        {
            if (enemies.Count < 3)
            {
                //TODO 3.0 enemies.Add(new Zombie());
                return enemies;
            }
            return enemies;
        }

        public override void SetImage()
        {
            _image = new BitmapImage(new Uri("/Properties/cards/ForestCard.png"));
            _tileImage = new BitmapImage(new Uri("/Properties/tiles/Forest.png"));
        }
    }
}
