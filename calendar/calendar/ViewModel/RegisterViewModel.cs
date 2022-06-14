using calendar.Common;
using calendar.Enums;
using calendar.Interfaces;
using calendar.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace calendar.ViewModel
{
        public class RegisterViewModel: CommonViewModelBase
        {
                private signup _signup;

                public signup signup
                {
                        get => _signup;
                        set => _signup = value;
                }

                private string _confirmpw;

                public string confirmpw
                {
                        get => _confirmpw;
                        set => _confirmpw = value;
                }

                private IDataBaseManager _dataBaseManager;
                public RegisterViewModel(IDataBaseManager dataBaseManager)
                {
                        this._dataBaseManager = dataBaseManager;
                        signup = new signup();
                }

                public RelayCommand NextPageCommand => new RelayCommand(() =>
                {
                        if (String.IsNullOrEmpty(signup.id))
                        {
                                MessageBox.Show("아이디 입력이 되어있지않습니다.");
                                return;
                        }
                        if (String.IsNullOrEmpty(signup.pw))
                        {
                                MessageBox.Show("패스워드 입력이 되어있지않습니다.");
                                return;
                        }
                        if (String.IsNullOrEmpty(confirmpw))
                        {
                                MessageBox.Show("패스워드 입력이 되어있지않습니다.");
                                return;
                        }
                        if (signup.pw != confirmpw)
                        {
                                MessageBox.Show("두개 의 패스워드가 일치하지 않습니다.");
                                return;
                        }
                        if (String.IsNullOrEmpty(signup.email))
                        {
                                MessageBox.Show("이메일 입력이 되어있지않습니다.");
                                return;
                        }

                        List<signup> signupMember = new DataBaseSelectFactory<signup>(this._dataBaseManager)
                                                .Select("select *from signup_tb");

                        var userId = signupMember.FirstOrDefault(x => x.id == signup.id);
                        if (userId != null) return;

                        int ret = this._dataBaseManager.Insert($"INSERT INTO signup_tb (id, pw, email) VALUES " +
                                                                   $"('{signup.id}'," +
                                                                   $"'{signup.pw}'," +
                                                                   $"'{signup.email}')");

                        if(ret == 0)
                        {
                                MessageBox.Show("등록에 실패하였습니다.");
                                return;
                        }

                        ret = this._dataBaseManager.Create($"CREATE TABLE "+$"{signup.id}_tb"+" (pid VARCHAR(45),day VARCHAR(45),what VARCHAR(45),tag VARCHAR(45),place VARCHAR(45))");



                    MovePage(new PageMove()
                        {
                                pageEnum = PageEnum.RegisterName,
                                data = signup.id
                        });
                }){};

                public RelayCommand CancelCommand => new RelayCommand(() =>
                {
                        MovePage(PageEnum.Login);
                });
        }
}
