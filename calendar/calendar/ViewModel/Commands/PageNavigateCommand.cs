using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calendar.ViewModel.Commands
{
    class PageNavigateCommand : ICommand
    {
        PageNavigateVM VMRef { get; set; }

        public PageNavigateCommand(PageNavigateVM vm)
        {
            VMRef = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string direction = (string)parameter;
            if (direction == "Ent") // 로그인 성공 , 회원가입 성공
            {
                VMRef.NavigateTo(VMRef.currentPageInd);
            }
            if (direction == "Can")
            {
                VMRef.NavigateTo(VMRef.currentPageInd - 1);
            }
            else
            {
                VMRef.NavigateTo(VMRef.currentPageInd + 1);
            }
        }
    }
}
