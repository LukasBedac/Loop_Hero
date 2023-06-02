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
    public class Slime : IEntity
    {
        private int _Hp;

        private int _Dmg;

        private BitmapImage _Image;

        public Slime()
        {
            _Hp = 60;
            _Dmg = 4;
            _Image = new BitmapImage(new Uri("../../../Properties/entity/slime.png", UriKind.Relative));
            
        }

        public int Hp { get => _Hp; set => _Hp += value; }

        public int Dmg { get => _Dmg; set => _Dmg += value; }

        public string Name { get => "Slime"; }

        public BitmapImage Image { get => _Image; set => _Image = value; }

        public void DrawImage(DrawingContext dc, int x, int y)
        {
            dc.DrawImage(_Image, new Rect(x, y, 30, 30));
        }
    }
}
