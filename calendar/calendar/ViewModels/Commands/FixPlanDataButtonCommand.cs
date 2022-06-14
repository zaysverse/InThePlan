using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    public class FixPlanDataButtonCommand : ICommand
    {
        public MainViewModel MV { get; set; }

        public FixPlanDataButtonCommand(MainViewModel mv)
        {
            MV = mv;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MV.FixPlanData();
        }
    }
}
