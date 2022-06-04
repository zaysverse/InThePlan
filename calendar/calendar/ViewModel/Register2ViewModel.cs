using calendar.Enums;
using calendar.Interfaces;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace calendar.ViewModel
{
        public class Register2ViewModel: CommonViewModelBase
        {
                private string _name;

                public string name
                {
                        get => _name;
                        set => Set(ref _name, value);
                }

                private readonly string _id;
                private IDataBaseManager _dataBaseManager;
                public Register2ViewModel(IDataBaseManager dataBaseManager, string id)
                {
                        this._dataBaseManager = dataBaseManager;
                        this._id = id;
                }

                public RelayCommand NameUpdateCommand => new RelayCommand(() =>
                {
                        int ret = this._dataBaseManager.Update($"UPDATE signup_tb SET name='{name}' where id='{this._id}'");
                        if (ret == 0)
                        {
                                MessageBox.Show("이름 적용에 실패하였습니다.");
                                return;
                        }

                        MovePage(PageEnum.Login);
                });
                public RelayCommand ExitCommand => new RelayCommand(() =>
                {
                        MovePage(PageEnum.Login);
                });
        }
}
