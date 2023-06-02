using Loop_Hero_GUI.Cards;
using Loop_Hero_GUI.Controls;
using Loop_Hero_GUI.Items;
using Loop_Hero_GUI.MapSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Loop_Hero_GUI.Entity
{
    public class Player : IEntity
    {
        private int _Hp;

        private int _Dmg;

        private BitmapImage _image;

        private List<Card>? _cards;

        private List<Item>? _items;

        private PlayerMovement _movement;

        private Card? _clickedCard;

        private int _actualTileIndex;

        public Player(int x, int y) 
        {
            _Hp = 100;
            _Dmg = 15;
            PositionX = x;
            PositionY = y;
            _image = new BitmapImage(new Uri("player.png"));
            _cards = new List<Card>();
            _items = new List<Item>();
            Movement = true;
            _movement = new(this);
            SetStartingCards();
        }
        #region Properties
        public string Name => throw new NotImplementedException();

        public int Hp { get => _Hp; set => _Hp = value; }

        public int Dmg { get => _Dmg; set => _Dmg = value; }
        
        public BitmapImage Image { get => _image; set => _image = value; }

        public int PositionX { get; set; }
        
        public int PositionY { get; set; }

        public bool Fight { get; set; }

        public bool Movement { get; set; }

        public int ActualTileIndex { get => _actualTileIndex; set => _actualTileIndex = value; }
        #endregion Properties
        public void DrawImage(DrawingContext dc, int x, int y)
        {
            dc.DrawImage(_image, new System.Windows.Rect(x, y, 48, 48));
            if (_cards != null )
            {
                foreach (Card card in _cards)
                {
                    card.DrawImage(dc);
                }
            }            
        }
        #region Cards
        private void SetStartingCards()
        {
            Random random = new();
            for (int i = 0; i < 5; i++)
            {
                int number = random.Next(0, 3);
                switch (number)
                {
                    case 0: 
                        _cards?.Add(new ForestCard(i));
                        break;
                    case 1:
                        _cards?.Add(new CemeteryCard(i));
                        break;
                    case 2:
                        _cards?.Add(new TreasureCard(i));
                        break;
                }
            }
        }
        public void AddCard(Card card)
        {
            if (_cards?.Count < 10)
            {
                _cards.Add(card);
                _cards = RearrangeCards();
            }
        }
        public void RemoveCard()
        {
            if (_clickedCard != null)
            {
                _cards?.Remove(_clickedCard);
                _cards = RearrangeCards();
            }
        }

        private List<Card> RearrangeCards()
        {
            List<Card> tempCards = new List<Card>();
            int index = 0;
            if (_cards != null)
            {
                foreach (Card? card in _cards)
                {
                    if (card != null)
                    {
                        tempCards.Add(card);
                        tempCards[index].PositionX = index * Card.CARD_SIZEX + 50;
                        tempCards[index].PositionY = 550;
                        index++;
                    }
                }
            }
            return tempCards;
        }
        public Card? CardOnClick(double x, double y)
        {
            if (_cards != null)
            {
                foreach (Card card in _cards)
                {
                    if (x >= card.PositionX && x < card.PositionX + Card.CARD_SIZEX && y >= card.PositionY && y < card.PositionY + Card.CARD_SIZEY) 
                    {
                        _clickedCard = card;
                        var name = card.GetCardName();
                        switch (name)
                        {
                            case "Forest":
                                return new ForestCard();
                            case "Cemetery":
                                return new CemeteryCard();
                            case "Treasure":
                                return new TreasureCard();

                        }
                    }
                }
            }
            return null;
        }
        #endregion Cards

        #region Movement
        public void ActivateMovement(MapDrawer map)
        {
            switch(_movement.Movement(map))
            {
                case "up":
                    MoveVertically(-1);
                    break;
                case "down": 
                    MoveVertically(1);
                    break;
                case "right":
                    MoveHorizontally(1);
                    break;
                case "left":
                    MoveHorizontally(-1);
                    break;
            }
        }

        private void MoveVertically(int y)
        {
            PositionY += y;
        }

        private void MoveHorizontally(int x)
        {
            PositionX += x;
        }
        #endregion Movement
    }
}
