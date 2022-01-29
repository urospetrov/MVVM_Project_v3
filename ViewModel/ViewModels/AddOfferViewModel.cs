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
        public MyICommand SelectionChangedCommand { get; set; }

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
            SelectionChangedCommand = new MyICommand(OnSelectionChanged);
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
            foreach(Offer offer in Offers)
            {
                if(offer.Id == IdVM)
                {
                    //Make special exception
                    throw new Exception();
                }
            }
            Offers.Add(new Offer(IdVM, NameVM, StartDateVM, ReturnDateVM, PriceVM, ImgPathVM));
        }

        private void OnUpdate()
        {
            //Error: Once the item is updated, SelectedItem property "dies" - 
            //- cannot change its values, the textboxes and datepickers remain locked-in

            /*
            foreach(Offer offer in Offers)
            {
                if(offer.Id == IdVM)
                {
                    offer.Name = NameVM;
                    offer.StartDate = StartDateVM;
                    offer.ReturnDate = ReturnDateVM;
                    offer.Price = PriceVM;
                    offer.ImgPath = ImgPathVM;
                }
            }
            */

            Offer updatedOffer = new Offer(IdVM, NameVM, StartDateVM, ReturnDateVM, PriceVM, ImgPathVM);
            Offer offer1 = null;
            foreach(Offer offer in Offers)
            {
                if(offer.Id == IdVM)
                {
                    offer1 = offer;
                }
            }
            if(offer1 is null)
            {
                //Updating non existant element exception
                throw new Exception();
            }
            Offers.Remove(offer1);
            Offers.Add(updatedOffer);
        }

        private void OnSelectionChanged()
        {
            if(SelectedOffer is null)
            {
                IdVM = 0;
                NameVM = "";
                StartDateVM = new DateTime(2022, 8, 1);
                ReturnDateVM = new DateTime(2022, 8, 11);
                PriceVM = 0;
                ImgPathVM = "";
                return;
            }
            IdVM = SelectedOffer.Id;
            NameVM = SelectedOffer.Name;
            StartDateVM = SelectedOffer.StartDate; 
            ReturnDateVM = SelectedOffer.ReturnDate;
            PriceVM = SelectedOffer.Price;
            ImgPathVM = SelectedOffer.ImgPath;
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
