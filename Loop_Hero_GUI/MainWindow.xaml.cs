using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Loop_Hero_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainGame? _mainGame;

        private int _progressBarValue;

        private int _day;


        public MainWindow()
        {
            InitializeComponent();
            _mainGame = new(this);
            this.ResizeMode = ResizeMode.NoResize;
            this.Focusable = true;
            this.Visibility = Visibility.Visible;
            _canvas.Children.Add(_mainGame);
            _mainGame.StartThread();
            _day = 1;
        }
        public bool SetDayProgressBar(int n)
        {
            if (n % 10 == 0) {
                _progressBarValue += 1;
                if (_progressBarValue != 100)
                {
                    _dayProgressBar.Value = _progressBarValue;
                    return false;
                } else
                {
                    _day += 1;
                    _DayCount.Text = "Day: " + _day;
                    _progressBarValue = 0;
                    _dayProgressBar.Value = _progressBarValue;
                    return true;
                }
            }
            return false;       
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new();
            this.Close();
            menu.Show();
        }

        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!_mainGame?.ThreadUp ?? true)
            {
                _mainGame?.StopThread();
                _pauseBtn.IsEnabled = false;
                _resumeBtn.IsEnabled = true;
            }
        }

        private void ResumeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_mainGame?.ThreadUp ?? false)
            {
                _mainGame?.StartThread();
                _resumeBtn.IsEnabled = false;
                _pauseBtn.IsEnabled = true;
            }
        }
    }
    
}
