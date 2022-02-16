using RabinKarpAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels
{
    public class RabinKarpViewModel : BindableBase
    {
        RabinKarp rabinKarp = new RabinKarp();
        public MyICommand SearchCommand { get; set; }

        private string baseString;
        private string pattern;
        private int cnt;
        public string BaseString
        {
            get { return baseString; }
            set
            {
                if (baseString != value)
                {
                    baseString = value;
                    OnPropertyChanged("BaseString");
                }
            }
        }
        public string Pattern
        {
            get { return pattern; }
            set
            {
                if (pattern != value)
                {
                    pattern = value;
                    OnPropertyChanged("Pattern");
                }
            }
        }
        public int Cnt
        {
            get { return cnt; }
            set
            {
                if (cnt != value)
                {
                    cnt = value;
                    OnPropertyChanged("Cnt");
                }
            }
        }

        public RabinKarpViewModel()
        {
            SearchCommand = new MyICommand(OnSearch);
        }

        private void OnSearch()
        {
            Cnt = rabinKarp.GetPatternCount(BaseString, Pattern);
        }
    }
}
