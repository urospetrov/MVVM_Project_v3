using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels
{
    public class AddOfferViewModel : BindableBase
    {
        public ObservableCollection<Offer> Offers { get; set; }

        public MyICommand BrowseCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        private Offer selectedOffer;

        public Offer SelectedOffer
        {
            get { return selectedOffer; }
            set
            {
                selectedOffer = value;

            }
        }

        private int idVM;
        private string nameVM;
        private DateTime startDateVM;
        private DateTime returnDateVM;
        private uint priceVM;
        private string imgPathVM;

        public AddOfferViewModel()
        {
            LoadOffers();
            BrowseCommand = new MyICommand(OnBrowse);
            AddCommand = new MyICommand(OnAdd);
            UpdateCommand = new MyICommand(OnUpdate);
        }

        public int IdVM
        {
            get { return idVM; }
            set
            {
                if (idVM != value) {
                    idVM = value;
                    OnPropertyChanged("IdVM");
                }
            }
        }
        public string NameVM
        {
            get { return nameVM; }
            set
            {
                if (nameVM != value)
                {
                    nameVM = value;
                    OnPropertyChanged("NameVM");
                }
            }
        }
        public DateTime StartDateVM
        {
            get { return startDateVM; }
            set
            {
                if(startDateVM != value)
                {
                    startDateVM = value;
                    OnPropertyChanged("StartDateVM");
                }
            }
        }
        public DateTime ReturnDateVM
        {
            get { return returnDateVM; }
            set
            {
                if(returnDateVM != value)
                {
                    returnDateVM = value;
                    OnPropertyChanged("ReturnDateVM");
                }
            }
        }
        public uint PriceVM
        {
            get { return priceVM; }
            set
            {
                if(priceVM != value)
                {
                    priceVM = value;
                    OnPropertyChanged("PriceVM");
                }
            }
        }
        public string ImgPathVM
        {
            get { return imgPathVM; }
            set
            {
                if (imgPathVM != value)
                {
                    imgPathVM = value;
                    OnPropertyChanged("ImgPathVM");
                }
            }
        }

        private void OnBrowse()
        {
            throw new NotImplementedException();
        }

        private void OnAdd()
        {
            Offer addedOffer = new Offer(IdVM, NameVM, StartDateVM, ReturnDateVM, PriceVM, ImgPathVM);
            if (Offers.Contains(addedOffer))
            {
                //Make spectial exception (folder also)
                throw new Exception();
            }
            Offers.Add(addedOffer);
        }

        private void OnUpdate()
        {
            throw new NotImplementedException();
        }

        public void LoadOffers()
        {
            ObservableCollection<Offer> offers = new ObservableCollection<Offer>();

            offers.Add(new Offer(1, "Name", new DateTime(2022, 1, 7), new DateTime(2022, 1, 17), 100, "Images/budva.jpg"));
            offers.Add(new Offer(2, "Name", new DateTime(2022, 1, 7), new DateTime(2022, 1, 17), 100, "Images/budva.jpg"));

            Offers = offers;
        }
    }
}
