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
        private DisplayOffersViewModel displayOffersViewModel = new DisplayOffersViewModel();
        private BindableBase currentViewModel;

        public MyICommand<string> NavCommand { get; set; }

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = displayOffersViewModel;
        }

        private void OnNav(string obj)
        {
            switch (obj)
            {
                case "display":
                    CurrentViewModel = displayOffersViewModel;
                    break;
                case "add":
                    CurrentViewModel = addOfferViewModel;
                    break;
            }
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
