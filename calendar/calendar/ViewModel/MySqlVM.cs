using calendar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace calendar.ViewModel
{
    class MySqlVM : ViewModelBase
    {
        public User_Info UserData { get; set; }

        public MySqlVM()
        {
            UserData = new User_Info();


        }


    }
}
