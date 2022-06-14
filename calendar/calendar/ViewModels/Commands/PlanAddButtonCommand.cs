using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;


namespace calendar.ViewModels.Commands
{
    public class PlanAddButtonCommand : ICommand
    {
        public MainViewModel MV { get; set; }

        public PlanAddButtonCommand(MainViewModel mv)
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
            MV.AddPlanData();
        }
    }
}
