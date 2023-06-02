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
        public MainWindow()
        {
            InitializeComponent();
            _mainGame = new(this);
            this.ResizeMode = ResizeMode.NoResize;
            this.Focusable = true;
            this.Visibility = Visibility.Visible;
            _canvas.Children.Add(_mainGame);
            _mainGame.StartThread();
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
                    _progressBarValue = 0;
                    _dayProgressBar.Value = 0;
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
            
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
