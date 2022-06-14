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

        private IDataBaseManager _dataBaseManager;
        public MainViewModel(IDataBaseManager dataBaseManager)
        {
            this._dataBaseManager = dataBaseManager;

            PlanFilter = new ObservableCollection<Plan>();
            DeleteButtonCommand = new DeleteButtonCommand(this);

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

        public void AddPlanData()
        {
            if(textWhat != null)
            {
                
                PlanFilter.Add(new Plan { 완료 = false, 날짜 = textDate.ToString("yyyy-MM-dd"), What = textWhat, Tag = textTag, 장소 = textPlace });
                
            }
        }

        private Plan selectedPlan;
        public Plan SelectedCity
        {
            get { return selectedPlan; }
            set { selectedPlan = value; }
        }

        public void FixPlanData()
        {
            if (selectedPlan != null)
            {
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
                PlanFilter.Remove(selectedPlan);
            }
        }

        public RelayCommand CalendarCommand => new RelayCommand(() =>
        {
            MovePage(PageEnum.Calendar);
        });

        public RelayCommand GalleryCommand => new RelayCommand(() =>
        {
            MovePage(PageEnum.Gallery);
        });
    }
}
