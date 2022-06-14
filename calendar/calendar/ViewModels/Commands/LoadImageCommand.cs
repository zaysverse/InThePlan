using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    class LoadImageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public GalleryViewModel VM { get; set; }

        public LoadImageCommand(GalleryViewModel vm)
        {
            VM = vm;
            
        }

        public LoadImageCommand()
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.LoadImage();
        }
    }
}
