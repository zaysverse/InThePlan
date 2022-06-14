using calendar.Enums;
using calendar.Model;
using GalaSoft.MvvmLight;

namespace calendar.ViewModel
{
        public class CommonViewModelBase : ViewModelBase
        {
                public void MovePage(PageEnum _pageEnum)
                {
                        MessengerInstance.Send(new PageMove()
                        {
                                pageEnum = _pageEnum
                        });
                }

                public void MovePage(PageMove _pageMove)
                {
                        MessengerInstance.Send(_pageMove);
                }
        }
}
