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
        private RabinKarpViewModel rabinKarpViewModel = new RabinKarpViewModel();
        private BindableBase currentViewModel;

        public MyICommand<string> NavCommand { get; set; }

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = addOfferViewModel;
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
                case "rabinkarp":
                    CurrentViewModel = rabinKarpViewModel;
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
