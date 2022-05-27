using calendar.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar.ViewModel
{
    class PageNavigateVM : INotifyPropertyChanged
    {
        public PageNavigateCommand PageNavigateCommand { get; set; }

        List<string> PageNames;

        private string currentPage;
        public string CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentPage"));
            }
        }
        public int currentPageInd { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public PageNavigateVM()
        {
            PageNavigateCommand = new PageNavigateCommand(this);

            PageNames = new List<string>();
            PageNames.Add("Pages/Intro.xaml");
            PageNames.Add("Pages/Login.xaml");
            PageNames.Add("Pages/Register.xaml");
            PageNames.Add("Pages/Register2.xaml");


            currentPageInd = 0;
            NavigateTo(currentPageInd);

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(3000);
            timer.Tick += new EventHandler(timer_Tick);

            timer.Start();


        }

        private void timer_Tick(object sender, EventArgs e)
        {
            NavigateTo(1);
            System.Windows.Threading.DispatcherTimer timer = (System.Windows.Threading.DispatcherTimer)sender;
            timer.Stop();
        }

        public void NavigateTo(int pageNum)
        {
            CurrentPage = PageNames[pageNum];
            currentPageInd = pageNum;
        }
    }
}
