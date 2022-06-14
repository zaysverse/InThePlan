using calendar.Common;
using calendar.Enums;
using calendar.Interfaces;
using calendar.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace calendar.ViewModel
{
        public class LoginViewModel: CommonViewModelBase
        {
                private string _id;
                public string id
                {
                        get => _id;
                        set => Set(ref _id, value);
                }

                private string _pw;

                public string pw
                {
                        get => _pw;
                        set => Set(ref _pw, value);
                }
                private IDataBaseManager _dataBaseManager;
                public LoginViewModel(IDataBaseManager dataBaseManager)
                {
                        this._dataBaseManager = dataBaseManager;
                }

                public RelayCommand RegisterCommand => new RelayCommand(() =>
                {
                        MovePage(PageEnum.RegisterInfo);                        
                });

                public RelayCommand LoginCommand => new RelayCommand(() =>
                {
                        if(String.IsNullOrEmpty(id))
                        {
                                MessageBox.Show("아이디를 입력해주세요.");
                                return;
                        }
                        if (String.IsNullOrEmpty(pw))
                        {
                                MessageBox.Show("패스워드를 입력해주세요.");
                                return;
                        }

                        List<signup> signupMember = new DataBaseSelectFactory<signup>(this._dataBaseManager)
                                                .Select($"select *from signup_tb where id ='{id}' and pw='{pw}'");
                        
                        if(signupMember.Count() == 0)
                        {
                                MessageBox.Show("로그인 실패");
                        }
                        else
                        {
                                MessageBox.Show("로그인 성공");
                                MovePage(PageEnum.Plan);
                    }
                });
        }
}
