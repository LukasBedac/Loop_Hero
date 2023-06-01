﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            SetDayProgressBar();
            
        }
        public void SetDayProgressBar()
        {
            _dayProgressBar.Value = 60;
        }
        
        public void Run()
        {
            while(true)
            {
                
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {

            base.OnRender(drawingContext);
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
