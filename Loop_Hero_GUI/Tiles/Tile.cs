using System.Collections.Generic;
using System.Windows.Controls;

namespace Loop_Hero_GUI.Tiles
{
    public abstract class Tile
    {
        private List<Entity> enemies;
        public Tile()
        {

        }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }

        public Image Image { get; set; }

    }
}