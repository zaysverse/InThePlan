using calendar.Enums;
using calendar.Model;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Controls;

namespace calendar.Views
{
        /// <summary>
        /// Intro.xaml에 대한 상호 작용 논리
        /// </summary>
        public partial class Intro : UserControl
        {

                System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
                public Intro()
                {
                        InitializeComponent();
                        timer.Interval = TimeSpan.FromMilliseconds(4000);
                        timer.Tick += new EventHandler(timer_Tick);

                        timer.Start();
                }


                private void timer_Tick(object sender, EventArgs e)
                {
                        timer.Stop();
                        this.Visibility = System.Windows.Visibility.Hidden;
                        Messenger.Default.Send(new PageMove()
                        {
                            pageEnum = PageEnum.Login
                        });
                }
        }
}
