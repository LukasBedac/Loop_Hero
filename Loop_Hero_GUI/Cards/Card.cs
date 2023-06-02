using Loop_Hero_GUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Loop_Hero_GUI.Cards
{
    
    public abstract class Card
    {
        public const int CARD_SIZEX = 110;
        
        public const int CARD_SIZEY = 130;

        public Card(int index) 
        { 
            PositionX = index * CARD_SIZEX + 50;
            PositionY = 520;
        }

        public Card()
        {

        }

        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public abstract void SetImage();

        public abstract void DrawImage(DrawingContext dc);

        public abstract void DrawTileImage(DrawingContext dc, int x, int y, int size);

        public abstract string GetCardName();

        public abstract List<IEntity> NewDay(List<IEntity> enemies);
    }
}
