using calendar.Common;
using calendar.Enums;
using calendar.Interfaces;
using calendar.Model;
using calendar.ViewModel;
using calendar.ViewModels.Commands;
using GalaSoft.MvvmLight.Command;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

            AddTDData();
            ShowTDData();

            TDCheckCommand = new TDCheckCommand(this);

        }

        //투두리스트 데이터베이스에 저장
        public void AddTDData()
        {
            if (Td1 == null && Td2 == null && Td3 == null && Td4 == null) return;
                this._dataBaseManager.Delete($"truncate {_id}_tb_c");
                int ret = this._dataBaseManager.Insert($"INSERT INTO " + $"{_id}_tb_c" + " (td1, td2, td3, td4) VALUES " +
                                                           $"('{Td1}'," +
                                                           $"'{Td2}'," +
                                                           $"'{Td3}'," +
                                                           $"'{Td4}')");

                if (ret == 0)
                {
                    MessageBox.Show("등록에 실패하였습니다.");
                    return;
                }
            
        }

        public void ShowTDData()
        {
            List<td> tdData = new DataBaseSelectFactory<td>(this._dataBaseManager)
                                                            .Select($"select *from {_id}_tb_c LIMIT 1");
            Td1 = tdData.ElementAt(0).td1;
            Td2 = tdData.ElementAt(0).td2;
            Td3 = tdData.ElementAt(0).td3;
            Td4 = tdData.ElementAt(0).td4;

        }

        public RelayCommand PlanCommand => new RelayCommand(() =>
        {
            MovePage(new PageMove()
            {
                pageEnum = PageEnum.Plan,
                data = this._id
            });
        });

        public TDCheckCommand TDCheckCommand { get; set; }
    }
}
