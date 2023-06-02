using Loop_Hero_GUI.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace Loop_Hero_GUI.Entity
{
    public class Zombie : Loot, IEntity
    {
        private int _Hp;

        private int _Dmg;

        private Item? _Item;

        private BitmapImage _Image;

        public Zombie()
        {
            _Hp = 160;
            _Dmg = 7;
            _Image = new BitmapImage(new Uri("zombie.png", UriKind.Relative));
            _Item = base.GenerateItem();
        }

        public int Hp { get => _Hp; set => _Hp += value; }

        public int Dmg { get => _Dmg; set => _Dmg += value; }

        public string Name { get => "Zombie"; }

        public Item? Loot { get => _Item; set => _Item = value; }

        public BitmapImage Image { get => _Image; set => _Image = value; }


        public void DrawImage(DrawingContext dc, int x, int y)
        {
            dc.DrawImage(_Image, new Rect(x, y, 40, 40));
        }
    }
}
