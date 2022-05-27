﻿using calendar.DB_Linkage;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calendar
{
    public interface IPageViewModel { }
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        MySQLManager manager = new MySQLManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();

        }
        private void closeButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();

        }
        private void minimizeButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = (this.WindowState != WindowState.Minimized) ? WindowState.Minimized : WindowState.Normal;
        }

    }
}