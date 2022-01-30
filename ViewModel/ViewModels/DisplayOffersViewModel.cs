using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels
{
    public class DisplayOffersViewModel : BindableBase
    {
        public static BindingList<Offer> Offers { get; private set; }
        private bool exists = false;
        public Offer offerToRemove = null;
        public DisplayOffersViewModel()
        {
            Offers = new BindingList<Offer>();
            foreach (Offer offer in AddOfferViewModel.OffersList)
            {
                exists = false;
                foreach(Offer offer1 in Offers)
                {
                    if(Offers.Contains(offer))
                    {
                        exists = true;
                        break;
                    }
                    else if(offer1.Id == offer.Id)
                    {
                        offerToRemove = offer1;
                        break;
                    }
                }
                if (!exists)
                {
                    if(offerToRemove != null)
                    {
                        Offers.Remove(offerToRemove);
                    }
                    Offers.Add(new Offer(offer.Id, offer.Name, offer.StartDate, offer.ReturnDate, offer.Price, offer.ImgPath));
                }
            }
        }
    }
}
