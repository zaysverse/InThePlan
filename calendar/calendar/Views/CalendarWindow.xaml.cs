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

namespace Listview_Filter_Test.Views
{
    /// <summary>
    /// CalendarWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CalendarWindow : Window
    {
        public CalendarWindow()
        {
            InitializeComponent();
        }

        private void ShowPlan_Click(object sender, RoutedEventArgs e)
        {
            Listview_Filter_Test.Views.PlanWindow1 SR = new Listview_Filter_Test.Views.PlanWindow1();

            SR.ShowDialog();
        }
    }
}
