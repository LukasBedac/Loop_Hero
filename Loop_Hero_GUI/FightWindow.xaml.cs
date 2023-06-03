using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Loop_Hero_GUI
{
    /// <summary>
    /// Interaction logic for FightWindow.xaml
    /// </summary>
    public partial class FightWindow : Window
    {
        private Fight _fight;
        public FightWindow(Fight fight)
        {
            InitializeComponent();
            _fight = fight;
            _canvas.Children.Add(_fight);
            this.Visibility = Visibility.Visible;
            this.Focusable = true;
            this.ResizeMode = ResizeMode.NoResize;

        }      
    }
}
