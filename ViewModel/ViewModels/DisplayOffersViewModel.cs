using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels
{
    public class DisplayOffersViewModel : BindableBase
    {
        public static ObservableCollection<Offer> Offers { get; private set; } = new ObservableCollection<Offer>
        {
                new Offer(1, "Herceg Novi", new DateTime(2022, 7, 1), new DateTime(2022, 7, 11), 250, "Images/herceg_novi.jpg"),
                new Offer(2, "Budva", new DateTime(2022, 8, 1), new DateTime(2022, 8, 11), 300, "Images/budva.jpg"),
                new Offer(3, "Canj", new DateTime(2022, 8, 11), new DateTime(2022, 8, 21), 200, "Images/canj.jpg")
        };
        private bool exists = false;
        public Offer offerToRemove = null;
        public DisplayOffersViewModel()
        {
            /*
            exists = false;
            foreach (Offer offer in AddOfferViewModel.OffersList)
            {
                foreach (Offer offer1 in Offers)
                {
                    if (offer1.Id == offer.Id)
                    {
                        if (Offers.Contains(offer))
                        {
                            exists = true;
                            break;
                        }
                        else
                        {
                            offerToRemove = offer1;
                            break;
                        }
                    }
                }
                if (!exists) {
                    if (offerToRemove != null)
                    {
                        Offers.Remove(offerToRemove);
                    }
                    Offers.Add(new Offer(offer.Id, offer.Name, offer.StartDate, offer.ReturnDate, offer.Price, offer.ImgPath));
                }
            }
            */
        }
    }
}
