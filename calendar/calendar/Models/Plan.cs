using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listview_Filter_Test.Models
{
    public class Plan : INotifyPropertyChanged
    {
        private string _date;
        public string 날짜
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(날짜));
            }
        }

        private string _what;
        public string What
        {
            get => _what;
            set
            {
                _what = value;
                OnPropertyChanged(nameof(What));
            }
        }

        private string _tag;
        public string Tag
        {
            get => _tag;
            set
            {
                _tag = value;
                OnPropertyChanged(nameof(Tag));
            }
        }

        private string _place;
        public string 장소
        {
            get => _place;
            set
            {
                _place = value;
                OnPropertyChanged(nameof(장소));
            }
        }

        public bool 완료 { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
