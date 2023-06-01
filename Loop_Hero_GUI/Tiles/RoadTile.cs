using Loop_Hero_GUI.Cards;
using Loop_Hero_GUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Loop_Hero_GUI.Tiles
{
    public class RoadTile : Tile
    {
        private List<IEntity>? _enemies;
        private BitmapImage? _image;

        public RoadTile(int row, int column)
        {

        }

        public override int NovyDen(bool novyDen)
        {
            throw new NotImplementedException();
        }

        public override void TileUsedCard(Card card)
        {
            throw new NotImplementedException();
        }

        public override void UpdateEnemies(bool novyDen)
        {
            throw new NotImplementedException();
        }

        public override void SetImage()
        {
            base.SetImage();
        }
    }
}
