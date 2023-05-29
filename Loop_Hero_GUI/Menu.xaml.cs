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
using Loop_Hero_GUI.Properties;
namespace Loop_Hero_GUI
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new();
            this.Close();
            mainWindow.Show();
            
        }

        private void ContinueBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO");
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
