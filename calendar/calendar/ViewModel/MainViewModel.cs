using calendar.Common;
using calendar.Enums;
using calendar.Interfaces;
using calendar.Model;
using calendar.ViewModels;
using GalaSoft.MvvmLight;
using System.Windows;

namespace calendar.ViewModel
{
        /// <summary>
        /// This class contains properties that the main View can data bind to.
        /// <para>
        /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
        /// </para>
        /// <para>
        /// You can also use Blend to data bind with the tool's support.
        /// </para>
        /// <para>
        /// See http://www.galasoft.ch/mvvm
        /// </para>
        /// </summary>
        public class MainViewModel : ViewModelBase
        {
                private Visibility _contentsView = Visibility.Hidden;

                public Visibility contentsView
                {
                        get => _contentsView;
                        set => Set(ref _contentsView, value);
                }

                private ViewModelBase _currentView;

                public ViewModelBase currentView
                {
                        get => _currentView;
                        set => Set(ref _currentView, value);
                }

                private IDataBaseManager _dataBaseManager;
                public MainViewModel(IDataBaseManager dataBaseManager)
                {
                        this._dataBaseManager = dataBaseManager;
                        this._dataBaseManager.Load();
                        MessengerInstance.Register<PageMove>(this, (page) =>
                        {
                                contentsView = Visibility.Visible;
                                switch (page.pageEnum)
                                {
                                        case PageEnum.Login:
                                                currentView = new LoginViewModel(this._dataBaseManager);
                                                return;
                                        case PageEnum.RegisterInfo:
                                                currentView = new RegisterViewModel(this._dataBaseManager);
                                                return;
                                        case PageEnum.RegisterName:
                                                currentView = new Register2ViewModel(this._dataBaseManager, (string)page.data);
                                                return;
                                        case PageEnum.Calendar:
                                            currentView = new CalendarViewModel(this._dataBaseManager, (string)page.data);
                                            return;
                                        case PageEnum.Gallery:
                                            currentView = new GalleryViewModel(this._dataBaseManager, (string)page.data);
                                            return;
                                        case PageEnum.Plan:
                                            currentView = new ViewModels.MainViewModel(this._dataBaseManager, (string)page.data);
                                            return;
                            }
                        });
                }
        }
}