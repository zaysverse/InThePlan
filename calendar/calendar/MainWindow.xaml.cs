using System.Windows;
using System.Windows.Input;

namespace calendar
{
        public interface IPageViewModel { }
        /// <summary>
        /// MainWindow.xaml에 대한 상호 작용 논리
        /// </summary>
        public partial class MainWindow : Window
        {
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
