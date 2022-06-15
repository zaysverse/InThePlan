using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    class TDCheckCommand : ICommand
    {
        private CalendarViewModel _calendar;

        public CalendarViewModel calendar
        {
            get { return _calendar; }
            set { _calendar = value; }
        }

        public TDCheckCommand(CalendarViewModel c)
        {
            calendar = c;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            calendar.AddTDData();
        }
    }
}
