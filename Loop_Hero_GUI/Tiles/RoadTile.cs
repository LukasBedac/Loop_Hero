using Loop_Hero_GUI.Cards;
using Loop_Hero_GUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Loop_Hero_GUI.Tiles
{
    public class RoadTile : Tile
    {
        private List<IEntity>? _enemies;
        private BitmapImage? _image;
        private Random? _random;

        public RoadTile(int row, int column)
        {
            base.Row = row;
            base.Column = column;
            this.SetImage();
            PositionX = column * TILE_SIZE;
            PositionY = row * TILE_SIZE;
            _enemies = new List<IEntity>();
            _random = new Random();
            if (_random.NextDouble() > 0.85)
            {
                _enemies.Add(new Slime());
            }
        }

        public override int PositionX { get; set; }
        public override int PositionY { get; set; }

        public override Card? UsedCard { get; set; }

        public override bool IsCardUsed { get; set; }

        public override string? TileName { get; set; }

        public override List<IEntity>? Enemies { get => _enemies; set => _enemies = value; }

        public override int NewDay(bool novyDen)
        {
            
            if (UsedCard != null && novyDen && _enemies != null)
            {
                _enemies = UsedCard.NewDay(_enemies);
            }
            else
            {
                if (novyDen && _random?.NextDouble() > 0.7 && _enemies?.Count < 4)
                {
                    _enemies.Add(new Slime());
                    UpdateEnemies(novyDen);
                    return 1;
                }
            }
            return 0;
        }

        public override void UpdateEnemies(bool novyDen)
        {
            if (novyDen && _enemies != null)
            {
                foreach (IEntity enemy in _enemies)
                {
                    enemy.Hp = 10;
                    enemy.Dmg = 1;
                }
            }
        }

        public override void SetImage() => _image = new BitmapImage(new Uri("../../../Properties/tiles/RoadTile.png", UriKind.Relative));
        
        public override void DrawImage(DrawingContext dc)
        {
            base.DrawImage(dc);
            if (UsedCard != null)
            {
                UsedCard.DrawTileImage(dc, PositionX, PositionY, TILE_SIZE);
            }
            if (_enemies != null && _enemies.Count > 0)
            {
                int i = 0;
                foreach (IEntity enemy in _enemies)
                {
                    if (i == 2)
                    {
                        enemy.DrawImage(dc, PositionX + (i * 10), PositionY + (i * 25));
                        return;
                    }
                    enemy.DrawImage(dc, PositionX + (i * 30), PositionY);
                    i++;
                }
            }
        }
        public override void TileUsedCard(Card card)
        {
            UsedCard = card;
            IsCardUsed = true;
        }
    }
}
