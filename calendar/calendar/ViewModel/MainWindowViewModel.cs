using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar.ViewModel
{
    class MainWindowViewModel :ViewModelBase
    {
        private IPageViewModel currentViewModel;
        private List<IPageViewModel> pageViewmodels;

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (pageViewmodels == null)
                    pageViewmodels = new List<IPageViewModel>();
                return pageViewmodels;
            }
        }

        public IPageViewModel CurrentViewModel
        {
            get
            {
                return currentViewModel;
            }
            set
            {
                currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentViewModel = PageViewModels.FirstOrDefault(viewmodel => viewmodel == viewModel);
        }

        public MainWindowViewModel()
        {
            PageViewModels.Add(new Login());
            PageViewModels.Add(new Register());

            CurrentViewModel = PageViewModels[0];

        }
    }
}
