using calendar.Enums;
using calendar.Interfaces;
using calendar.Model;
using calendar.ViewModel;
using calendar.ViewModels.Commands;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace calendar.ViewModels
{
    class GalleryViewModel : CommonViewModelBase
    {
        private Image newImage;

        public Image NewImage
        {
            get { return newImage; }
            set
            {
                newImage = value;
            }
        }

        private Image selectedImage;

        public Image SelectedImage
        {
            get { return selectedImage; }
            set { selectedImage = value; }
        }

        private Image delImage;

        public Image DelImage
        {
            get { return delImage; }
            set { delImage = value; }
        }

        public LoadImageCommand LoadImageCommand { get; set; }
        public ObservableCollection<Image> images { get; set; }
        public DeleteImageCommand DeleteImageCommand { get; set; }

        private readonly string _id;
        private IDataBaseManager _dataBaseManager;
        public GalleryViewModel(IDataBaseManager dataBaseManager, string id)
        {
            this._dataBaseManager = dataBaseManager;
            this._id = id;
            NewImage = new Image();
            LoadImageCommand = new LoadImageCommand(this);
            images = new ObservableCollection<Image>();
            DeleteImageCommand = new DeleteImageCommand(this);

        }

        public void LoadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                if (NewImage != null)
                {
                    //foreach(var file in openFileDialog.FileName)

                    Uri fileUri = new Uri(openFileDialog.FileName);
                    NewImage.Source = new BitmapImage(fileUri);

                    images.Add(new Image() { Source = NewImage.Source });

                    
                }
            }
        }

        public void DeleteImage()
        {
            if(images.LongCount() <= 0)
            {
                //삭제할 이미지가 없을때 아무 동작 없음
            }
            else
            {
                images.RemoveAt(0);
            }
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
