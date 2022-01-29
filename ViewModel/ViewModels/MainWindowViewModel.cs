using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private AddOfferViewModel addOfferViewModel = new AddOfferViewModel();
        private BindableBase currentViewModel;
        public MainWindowViewModel()
        {
            CurrentViewModel = addOfferViewModel;
        }
        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }
    }
}
