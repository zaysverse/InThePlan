using calendar.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using calendar.ViewModels.Commands;
using System.Windows.Controls;
using calendar.ViewModel;
using calendar.Interfaces;
using GalaSoft.MvvmLight.Command;
using calendar.Enums;
using System.Windows;
using calendar.Common;
using calendar.Model;

namespace calendar.ViewModels
{
    public class MainViewModel : CommonViewModelBase
    {
        #region Properties
        private string _filter = string.Empty;
        public string Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                OnFilterChanged();
            }
        }

        private DateTime textDate = DateTime.Now;
        public DateTime TextDate
        {
            get { return textDate; }
            set { textDate = value;}
        }

        private DateTime fixDate = DateTime.Now;
        public DateTime FixDate
        {
            get { return fixDate; }
            set { fixDate = value;}
        }

        private string textWhat;
        public string TextWhat
        {
            get { return textWhat; }
            set { textWhat = value; }
        }

        private string fixWhat;
        public string FixWhat
        {
            get { return fixWhat; }
            set { fixWhat = value; }
        }

        private string textTag;

        public string TextTag
        {
            get { return textTag; }
            set { textTag = value; }
        }

        private string fixTag;

        public string FixTag
        {
            get { return fixTag; }
            set { fixTag = value; }
        }

        private string textPlace;

        public string TextPlace
        {
            get { return textPlace; }
            set { textPlace = value; }
        }

        private string fixPlace;
        public string FixPlace
        {
            get { return fixPlace; }
            set { fixPlace = value; }
        }

        public ObservableCollection<Plan> PlanFilter { get; set; }

        private CollectionViewSource PlanCollectionViewSource { get; set; }

        public ICollectionView PlanCollection
        {
            get { return PlanCollectionViewSource.View; }
        }
        #endregion

        public DeleteButtonCommand DeleteButtonCommand { get; set; }

        public PlanAddButtonCommand PlanAddButtonCommand { get; set; }
        
        public FixPlanDataButtonCommand FixPlanDataButtonCommand { get; set; }

        private readonly string _id;
        private IDataBaseManager _dataBaseManager;
        public MainViewModel(IDataBaseManager dataBaseManager, string id)
        {
            this._dataBaseManager = dataBaseManager;
            this._id = id;

            PlanFilter = new ObservableCollection<Plan>();
            DeleteButtonCommand = new DeleteButtonCommand(this);
            ShowPlanData();
            AddPlanData();

            PlanAddButtonCommand = new PlanAddButtonCommand(this);

            FixPlanDataButtonCommand = new FixPlanDataButtonCommand(this);

            PlanCollectionViewSource = new CollectionViewSource();
            PlanCollectionViewSource.Source = this.PlanFilter;
            PlanCollectionViewSource.Filter += ApplyFilter;
        }

        private void OnFilterChanged()
        {
            PlanCollectionViewSource.View.Refresh();
        }

        void ApplyFilter(object sender, FilterEventArgs e)
        {
            Plan svm = (Plan)e.Item;

            if (string.IsNullOrWhiteSpace(this.Filter) || this.Filter.Length == 0)
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = svm.What.ToLower().Contains(Filter.ToLower()) || svm.Tag.ToLower().Contains(Filter.ToLower()) || svm.장소.ToLower().Contains(Filter.ToLower());
            }
        }

        //데이터베이스에 저장된 일정들을 화면에 연결
        void ShowPlanData()
        {
            ObservableCollection<Plan> planData = new ObservableCollection<Plan>();

            planData = new DataBaseSelectFactory<Plan>(this._dataBaseManager)
                                        .SelectPlan(_id);
            PlanFilter = planData;
        }

        //일정 추가
        public void AddPlanData()
        {
            if(textWhat != null)
            {
                PlanFilter.Add(new Plan { 완료 = false, 날짜 = textDate.ToString("yyyy-MM-dd"), What = textWhat, Tag = textTag, 장소 = textPlace });


                //List<Plan> signupMember = new DataBaseSelectFactory<Plan>(this._dataBaseManager)
                //                        .Select("select *from signup_tb");

                int ret = this._dataBaseManager.Insert($"INSERT INTO " + $"{_id}_tb" + " (day, what, tag, place) VALUES " +
                                                           $"('{textDate.ToString("yyyy-MM-dd")}'," +
                                                           $"'{textWhat}'," +
                                                           $"'{textTag}'," +
                                                           $"'{textPlace}')");

                if (ret == 0)
                {
                    MessageBox.Show("등록에 실패하였습니다.");
                    return;
                }
            }
        }

        private Plan selectedPlan;
        public Plan SelectedCity
        {
            get { return selectedPlan; }
            set { selectedPlan = value; }
        }

        // 일정 수정
        public void FixPlanData()
        {
            if (selectedPlan != null)
            {
                new DataBaseSelectFactory<Plan>(this._dataBaseManager)
                                                .UpdatePlan(_id, selectedPlan,this);

                selectedPlan.날짜 = fixDate.ToString("yyyy-MM-dd");
                selectedPlan.What = fixWhat;
                selectedPlan.Tag = fixTag;
                selectedPlan.장소 = fixPlace;
            }
        }



        public void DeletePlanData()
        {
            if (selectedPlan != null)
            {
                int ret = this._dataBaseManager.Delete($"DELETE FROM  " + $"{_id}_tb" + " WHERE " +
                                                           $"day = '{selectedPlan.날짜.ToString()}' AND " +
                                                           $"what = '{selectedPlan.What}' AND " +
                                                           $"tag = '{selectedPlan.Tag}' AND " +
                                                           $"place = '{selectedPlan.장소}'");
                if (ret == 0)
                {
                    MessageBox.Show("등록에 실패하였습니다.");
                    return;
                }
                PlanFilter.Remove(selectedPlan);

            }
        }

        public RelayCommand CalendarCommand => new RelayCommand(() =>
        {
            MovePage(new PageMove()
            {
                pageEnum = PageEnum.Calendar,
                data = this._id
            });
        });

        public RelayCommand GalleryCommand => new RelayCommand(() =>
        {
            MovePage(new PageMove()
            {
                pageEnum = PageEnum.Gallery,
                data = this._id
            });
        });
    }
}
