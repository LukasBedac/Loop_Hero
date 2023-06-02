using Loop_Hero_GUI.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Loop_Hero_GUI.Entity
{
    public class Treasure : Loot, IEntity
    {
        private int _Hp;

        private int _Dmg;

        private Item? _Item;

        private BitmapImage _Image;

        public Treasure()
        {
            _Hp = 30;
            _Dmg = 17;
            _Image = new BitmapImage(new Uri("chest.png", UriKind.Relative));
            _Item = base.GenerateItem();
        }

        public int Hp { get => _Hp; set => _Hp += value; }

        public int Dmg { get => _Dmg; set => _Dmg += value; }

        public string Name { get => "Treasure Chest"; }

        public Item? Loot { get => _Item; set => _Item = value; }

        public BitmapImage Image { get => _Image; set => _Image = value; }


        public void DrawImage(DrawingContext dc, int x, int y)
        {
            dc.DrawImage(_Image, new Rect(x + 10, y + 10, 40, 40));
        }
    }
}
