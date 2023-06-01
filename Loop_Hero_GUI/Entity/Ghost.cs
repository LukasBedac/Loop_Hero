using Loop_Hero_GUI.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Loop_Hero_GUI.Entity
{
    public class Ghost : IEntity
    {
        private int _Hp;

        private int _Dmg;

        private Item? _Item;

        private BitmapImage _Image;

        public Ghost() 
        {
            _Hp = 120;
            _Dmg = 9;
            _Image = new BitmapImage(new Uri("Properties/entity/duch.png"));

        }

       
        public int Hp { get => _Hp; init => _Hp += value; }
        public int Dmg { get =>_Dmg; init => _Dmg += value; }
        public string Name { get => "Ghost"; }
        public Item? Loot { get => _Item; set => _Item = value; }
        public BitmapImage Image { get => _Image; set => _Image = value; }


        public void DrawImage(DrawingContext dc, int x, int y)
        {
            
        }
    }
}
