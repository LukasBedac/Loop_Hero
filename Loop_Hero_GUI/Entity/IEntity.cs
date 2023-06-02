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
    public interface IEntity
    {
        string Name { get; }

        int Hp { get; set; }

        int Dmg { get; set; }

        BitmapImage Image {  get; set; }

        void DrawImage(DrawingContext dc, int x, int y);
    }
}
