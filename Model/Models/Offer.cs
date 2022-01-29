using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Offer : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private DateTime startDate;
        private DateTime returnDate;
        private uint price;
        private string imgPath;

        public Offer(int id, string name, DateTime startDate, DateTime returnDate, uint price, string imgPath)
        {
            this.Id = id;
            this.Name = name;
            this.StartDate = startDate;
            this.ReturnDate = returnDate;
            this.Price = price;
            this.ImgPath = imgPath;
        }

        public int Id
        {
            get{ return id; }
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                RaisePropertyChanged("StartDate");
            }
        }

        public DateTime ReturnDate
        {
            get { return returnDate; }
            set
            {
                returnDate = value;
                RaisePropertyChanged("ReturnDate");
            }
        }

        public uint Price
        {
            get { return price; }
            set
            {
                price = value;
                RaisePropertyChanged("Price");
            }
        }

        public string ImgPath
        {
            get { return imgPath; }
            set
            {
                imgPath = value;
                RaisePropertyChanged("ImgPath");
            }
        }

        public override string ToString()
        {
            return $"{Id} {Name} {StartDate} {ReturnDate} {Price} {ImgPath}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Offer offer &&
                   Id == offer.Id &&
                   Name == offer.Name &&
                   StartDate == offer.StartDate &&
                   ReturnDate == offer.ReturnDate &&
                   Price == offer.Price &&
                   ImgPath == offer.ImgPath;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, StartDate, ReturnDate, Price, ImgPath);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
