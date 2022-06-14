using calendar.Interfaces;
using GalaSoft.MvvmLight;

namespace calendar.Model
{
        public class signup : ObservableObject
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

                private string _email;
                public string email
                {
                        get => _email;
                        set => Set(ref _email, value);
                }

                private string _name;
                public string name
                {
                        get => _name;
                        set => Set(ref _name, value);
                }
        }
}
