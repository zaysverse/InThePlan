using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar.Model
{
    class td : ObservableObject
    {
        private string _td1;
        public string td1
        {
            get => _td1;
            set => Set(ref _td1, value);
        }

        private string _td2;
        public string td2
        {
            get => _td2;
            set => Set(ref _td2, value);
        }
        private string _td3;
        public string td3
        {
            get => _td3;
            set => Set(ref _td3, value);
        }
        private string _td4;
        public string td4 
        {
            get => _td4;
            set => Set(ref _td4, value);
        }

    }
}
