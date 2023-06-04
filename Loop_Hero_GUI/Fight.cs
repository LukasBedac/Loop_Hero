using Loop_Hero_GUI.Cards;
using Loop_Hero_GUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Loop_Hero_GUI
{
    public class Fight : Canvas
    {
        private Player? _player;

        private List<IEntity>? _enemies;

        private MainGame? _mainGame;

        private MainWindow? _mainWindow;

        private ListBox _listBox;

        private Random _random;

        private DispatcherTimer _timer;

        //private FightWindow _window;

        public Fight(Player player, List<IEntity> enemies, MainGame mainGame, MainWindow window, ListBox text)
        {
            _timer = new DispatcherTimer();
            _player = player;
            _enemies = enemies;
            _mainGame = mainGame;
            _mainWindow = window;
            _listBox = text;
            _random = new Random();
            BeginFight(_enemies);
        }
        /*PlayerTurn = true;

        _window = new(this);
        _window._enemyBar1.Visibility = Visibility.Hidden;
        _window._enemyBar2.Visibility = Visibility.Hidden;
        _window._enemyBar3.Visibility = Visibility.Hidden;
        StartThread();
        _timer.Tick += Timer_Tick;

    }
    public bool PlayerTurn { get; set; }
    protected override void OnRender(DrawingContext dc)
    {
        base.OnRender(dc);           
        BeginFightDraw(dc);
        InvalidateVisual();
        if (_player?.Hp > 0 && _enemies != null)
        {
            int enemiesAlive = 0;
            foreach (IEntity enemy in _enemies)
            {
                if (enemy.Hp > 0)
                {
                    enemiesAlive++;
                    continue;
                }
            }
            if (enemiesAlive > 0)
            {
                _timer.Tick += Timer_Tick;
            } 
        }
    }
    private void Timer_Tick(object? sender, EventArgs e)
    {

        _timer.Interval = TimeSpan.FromMilliseconds(500);
        for (int i = 0; i < _enemies?.Count; i++)
        {
            double chance = _random.NextDouble();
            {
                if (PlayerTurn)
                {
                    if (_player != null && chance > 0.7)
                    {
                        _enemies[i].Hp = -(_player.Dmg * 2);
                        DrawDmgNumbers(chance, _enemies[i]);
                    } else
                    {
                        _enemies[i].Hp = -(_player!.Dmg);
                        DrawDmgNumbers(chance, _enemies[i]);
                    }
                }
                else
                {
                    if (chance > 0.6)
                    {
                        DrawDmgNumbers(chance, _enemies[i]);
                    } else
                    {
                        _player!.Hp = -(_enemies[i].Dmg);
                        DrawDmgNumbers(chance, _enemies[i]);
                    }
                }

            }
            if (_player?.Hp < 0 || _enemies[i].Hp < 0)
            {
                _window.Close();
            } 
        }           
    }

    public void BeginFightDraw(DrawingContext dc)
    {
        dc.DrawImage(_player?.Image, new Rect(75, 70, 96, 96));
        _window._playerBar.Maximum = _window._playerBar.Value = _player?.Hp ?? 0;
        if (_enemies != null)
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                dc.DrawImage(_enemies[i].Image, new Rect(350, 220 - (i * 100), 60, 60));
                if (i == 0)
                {
                    _window._enemyBar1.Maximum = _window._enemyBar1.Value = _enemies[i].Hp;
                    _window._enemyBar1.Visibility = Visibility.Visible;
                } else if (i == 1)
                {
                    _window._enemyBar2.Maximum = _window._enemyBar2.Value = _enemies[i].Hp;
                    _window._enemyBar2.Visibility = Visibility.Visible;
                } else if (i == 2)
                {
                    _window._enemyBar3.Maximum = _window._enemyBar3.Value = _enemies[i].Hp;
                    _window._enemyBar3.Visibility = Visibility.Visible;
                }                   
            }
        }           
    }

    public void DrawDmgNumbers(double chance, IEntity enemy)
    {
        if (PlayerTurn)
        {
            if (chance > 0.7)
            {
                _window._playerDmg.Text = $"{_player?.Dmg * 2}";
                Thread.Sleep(500);
                _window._playerDmg.Text = "";
            } else
            {

                _window._playerDmg.Text = $"{_player?.Dmg}";
                Thread.Sleep(500);
                _window._playerDmg.Text = "";
            }
        } else
        {
            if (chance > 0.6)
            {
                _window._enemyDmgType.Text = $"{enemy.Name}";
                _window._enemyDmg.Text = $"{enemy?.Dmg}";
                _window._playerDmg.Text = "Dodged!";
                Thread.Sleep(500);
                _window._enemyDmg.Text = "";
            } else
            {
                _window._enemyDmgType.Text = $"{enemy.Name}";
                _window._enemyDmg.Text = $"{enemy?.Dmg}";
                Thread.Sleep(500);
                _window._enemyDmg.Text = "";
            }
        }
        this.InvalidateVisual();
    }
    public void StartThread()
    {

        _timer.Start();
    } */
        private void BeginFight(List<IEntity> enemies)
        {
            bool playerTurn = true;
            Color playerColor = (Color)ColorConverter.ConvertFromString("#E2C044");
            SolidColorBrush playerBrush = new SolidColorBrush(playerColor);
            for (int i = 0; i < enemies.Count; i++)
            {
                IEntity enemy = enemies[i];
                _listBox.Items.Add("-----------------------------------------------");
                _listBox.Items.Add("We found an enemy on our tile!");
                _listBox.Items.Add("Type of enemy: " +  enemy.Name);
                _listBox.Items.Add("Enemy HP: " + enemy.Hp);
                _listBox.Items.Add("-----------------------------------------------");
                _listBox.InvalidateVisual();
                while(_player?.Hp > 0 && enemy.Hp > 0)
                {
                    Thread.Sleep(50);
                    double crtiChance = _random.NextDouble();
                    double dodge = _random.NextDouble();
                    if (playerTurn)
                    {
                        _listBox.Items.Add("-----------------");                       
                        _listBox.Items.Add("--PLAYER ATTACK--");                        
                        _listBox.UpdateLayout();                       
                        if (crtiChance > 0.7) 
                        {
                            _listBox.Items.Add("Player dealt damage " + _player?.Dmg);
                            enemy.Hp = -(_player!.Dmg * 2);
                            _listBox.Items.Add("Enemy HP: " + enemy.Hp);
                            _listBox.Items.Add("-----------------");
                            _listBox.UpdateLayout();
                        } else
                        {
                            _listBox.Items.Add("Player dealt damage " + _player?.Dmg);
                            enemy.Hp = -(_player!.Dmg);
                            _listBox.Items.Add("Enemy HP: " + enemy.Hp);
                            _listBox.Items.Add("-----------------");
                            _listBox.UpdateLayout();
                        }
                    } else
                    {
                        _listBox.Items.Add("-----------------");
                        _listBox.Items.Add($"--{enemy.Name.ToUpper()} ATTACK--");
                        if (dodge > 0.3)
                        {
                            _listBox.Items.Add("Player dodged an enemy attack");
                            _listBox.Items.Add($"Player HP: {_player?.Hp}");
                            _listBox.Items.Add("-----------------");
                        } else
                        {
                            _listBox.Items.Add($"{enemy.Name} dealt damage {enemy.Dmg}");
                            _player!.Hp = -(enemy.Dmg);
                            _listBox.Items.Add($"Player HP: {_player?.Hp}");
                            _listBox.Items.Add("-----------------");
                        }
                        
                    }
                    playerTurn = !playerTurn;
                    Thread.Sleep( 50);
                }
                if (_player?.Hp <= 0)
                {
                   _listBox.Items.Add("Enemy won a battle against us");
                   _listBox.Items.Add("-----------------------------------------------");
                    MessageBox.Show(_mainWindow, "You lost", "Lost", MessageBoxButton.OK);
                    Thread.Sleep(20000);
                    System.Environment.Exit(0);
                } else
                {
                    _listBox.Items.Add("We won a battle against our enemies, lets continue");
                    _listBox.Items.Add("-----------------------------------------------");
                    _enemies?.Clear();
                }
                string loot = "";
                ListBoxItem item = new ListBoxItem();
                double cardLoot = _random.NextDouble();
                if (cardLoot > 0.75)
                {
                    _player?.AddCard(new TreasureCard());
                    loot ="You got a card: Treasure";
                    item.Content = new TextBlock()
                    {
                        Text = loot,
                        TextWrapping = TextWrapping.Wrap,
                        Foreground = Brushes.Red,
                    };
                     
                    
                } else if (cardLoot > 0.5) 
                {
                    _player?.AddCard(new CemeteryCard());
                     loot = "You got a card: Cemetery";
                    item.Content = new TextBlock()
                    {
                        Text = loot,
                        TextWrapping = TextWrapping.Wrap,
                        Foreground = Brushes.Red,
                    };

                }
                else if (cardLoot > 0.25)
                {
                    _player?.AddCard(new ForestCard());
                    loot = "You got a card: Forest";
                    item.Content = new TextBlock()
                    {
                        Text = loot,
                        TextWrapping = TextWrapping.Wrap,
                        Foreground = Brushes.Red,
                    };

                }
                _listBox.Items.Add(item);
            }
        }
    }
}
