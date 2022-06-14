using Listview_Filter_Test.Models;
using Listview_Filter_Test.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Listview_Filter_Test.Views
{
    /// <summary>
    /// PlanWindow1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PlanWindow1 : Window
    {
        //private MainViewModel _viewModel;
        public PlanWindow1()
        {
            InitializeComponent();

            //_viewModel = new MainViewModel();
            //this.DataContext = _viewModel;
        }

        private GridViewColumnHeader lastClickedGridViewColumnHeader = null;
        private ListSortDirection lastListSortDirection = ListSortDirection.Ascending;

        private void gridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader clickedGridViewColumnHeader = e.OriginalSource as GridViewColumnHeader;

            ListSortDirection listSortDirection;

            if (clickedGridViewColumnHeader != null)
            {
                if (clickedGridViewColumnHeader.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (clickedGridViewColumnHeader != this.lastClickedGridViewColumnHeader)
                    {
                        listSortDirection = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (this.lastListSortDirection == ListSortDirection.Ascending)
                        {
                            listSortDirection = ListSortDirection.Descending;
                        }
                        else
                        {
                            listSortDirection = ListSortDirection.Ascending;
                        }
                    }

                    string header = clickedGridViewColumnHeader.Column.Header as string;

                    Sort(header, listSortDirection);

                    this.lastClickedGridViewColumnHeader = clickedGridViewColumnHeader;
                    this.lastListSortDirection = listSortDirection;
                }
            }
        }

        private void Sort(string header, ListSortDirection listSortDirection)
        {
            if (this.listlist.ItemsSource != null)
            {
                ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.listlist.ItemsSource);

                collectionView.SortDescriptions.Clear();

                SortDescription sortDescription = new SortDescription(header, listSortDirection);

                collectionView.SortDescriptions.Add(sortDescription);

                collectionView.Refresh();
            }
        }

        private void ShowCalendar_Click(object sender, RoutedEventArgs e)
        {
            Listview_Filter_Test.Views.CalendarWindow SR = new Listview_Filter_Test.Views.CalendarWindow();

            SR.ShowDialog();
        }


        private void ShowGalleryButton_Click(object sender, RoutedEventArgs e)
        {
            Listview_Filter_Test.Views.GalleryWindow SR = new Listview_Filter_Test.Views.GalleryWindow();

            SR.ShowDialog();
        }
    }
}
