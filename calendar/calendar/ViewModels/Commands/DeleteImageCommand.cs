using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Listview_Filter_Test.ViewModels.Commands
{
    class DeleteImageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public GalleryViewModel VM { get; set; }

        public DeleteImageCommand(GalleryViewModel vm)
        {
            VM = vm;
        }

        public DeleteImageCommand()
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.DeleteImage();
        }
    }
}
