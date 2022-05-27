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

namespace calendar.Pages
{
    /// <summary>
    /// Register.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }
        /*
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Pages/Register2.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Pages/Login.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }*/
    }
}
