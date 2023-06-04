using Loop_Hero_GUI.Cards;
using Loop_Hero_GUI.Entity;
using Loop_Hero_GUI.MapSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Loop_Hero_GUI
{
    public class MainGame : Canvas
    {
        private DispatcherTimer _timer;

        private MapDrawer? _map;

        private MainWindow? _mainWindow;

        private Card? _clickedCard;

        private int _progressBarCounter;

        public MainGame(MainWindow mainWindow) 
        {
            _timer = new DispatcherTimer();
            _timer.Tick += Timer_Tick;
            _mainWindow = mainWindow;
            ThreadUp = false;
            NewDay = false;
            _map = new MapDrawer();
            Player = new(_map.StarterTile[1], _map.StarterTile[0]);
            this.MouseLeftButtonDown += MainGame_MouseLeftButtonDown;
            _progressBarCounter = 0;

        }

        private void MainGame_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_clickedCard == null && Player?.CardOnClick(e.GetPosition(this).X, e.GetPosition(this).Y) != null)
            {
                _clickedCard = Player.CardOnClick(e.GetPosition(this).X, e.GetPosition(this).Y);
                Player.Movement = false;
                Highlighted = true;
            } else
            {
                if (_clickedCard != null && _map != null)
                {
                    var changed = _map.ForwardClickedCardToTile(_clickedCard, e.GetPosition(this).X, e.GetPosition(this).Y);
                    if (changed)
                    {
                        Player?.RemoveCard();
                    }
                    _clickedCard = null;
                    if (Player != null)
                    {
                        Player.Movement = true;
                    }
                    Highlighted = false;

                }
            }
        }

        public bool NewDay { get; set; }
        
        public bool ThreadUp { get; set; }

        public bool Highlighted { get; set; }

        public Player? Player { get; set; }
        
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            _map?.NewDay(NewDay);
            _map?.DrawMap(dc);
            if (Highlighted)
            {
                _map?.ClickedCardDraw(dc);
            }
            Player?.DrawImage(dc, Player.PositionX, Player.PositionY);
            if (_mainWindow != null)
            {
                _mainWindow._playerHPText.Text = "HP: " + Player?.Hp.ToString();
                _mainWindow._playerHPBar.Value = Player!.Hp;
                _mainWindow._cardsText.Text = $"Maximum number of cards: 10\n Current Number of cards is {Player.Cards?.Count}";
            }
            this.InvalidateVisual();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            //_timer.Interval = TimeSpan.FromMilliseconds(10);
            Thread.Sleep(10);
            if (_clickedCard == null && _mainWindow != null)
            {
                _progressBarCounter += (_progressBarCounter <= 100) ? 1 : -100;
                NewDay = _mainWindow.SetDayProgressBar(_progressBarCounter);                   
            }
            if (_map != null)
            {
                Player?.ActivateMovement(_map);
            }
            if (Player != null && Player.Fight && _map != null)
            {
                StopThread();
                Player.ActivateMovement(_map);
            }
            if (Player != null && !ThreadUp && Player.Fight)
            {
                StopThread();
                if (_map != null && _mainWindow != null && _mainWindow._listBox != null) 
                {
                Player.StartFight(_map, this, _mainWindow, _mainWindow._listBox);

                }
                ResumeThread();
            }
            InvalidateVisual();

        }

        public void StopThread()
        {
            ThreadUp = false;
            _timer.Stop();
        }

        public void StartThread()
        {
            ThreadUp = true;
            _timer.Start();
        }

        public void ResumeThread()
        {
            ThreadUp = true;
            _timer.Start();
        }
    }
}
