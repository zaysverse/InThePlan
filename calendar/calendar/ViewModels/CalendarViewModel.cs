using calendar.Enums;
using calendar.Interfaces;
using calendar.Model;
using calendar.ViewModel;
using GalaSoft.MvvmLight.Command;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar.ViewModels
{
    class CalendarViewModel : CommonViewModelBase
    {
        private string _td1;
        public string Td1
        {
            get => _td1;
            set => Set(ref _td1, value);
        }

        private string _td2;
        public string Td2
        {
            get => _td2;
            set => Set(ref _td2, value);
        }
        private string _td3;
        public string Td3
        {
            get => _td3;
            set => Set(ref _td3, value);
        }

        private string _td4;
        public string Td4
        {
            get => _td4;
            set => Set(ref _td4, value);
        }

        private readonly string _id;
        private IDataBaseManager _dataBaseManager;
        public CalendarViewModel(IDataBaseManager dataBaseManager, string id)
        {
            this._dataBaseManager = dataBaseManager;
            this._id = id;

        }
        
        public RelayCommand PlanCommand => new RelayCommand(() =>
        {
            MovePage(new PageMove()
            {
                pageEnum = PageEnum.Plan,
                data = this._id
            });
        });
    }
}
