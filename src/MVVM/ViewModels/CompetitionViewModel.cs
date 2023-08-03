using mvvm_rocketlanding.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_rocketlanding.MVVM.ViewModels
{
    
    class CompetitionViewModel : ObservableObject
    {
        public RelayCommand SendData { get; set; }

        private string _userFirst;

        public string UserFirst
        {
            get { return _userFirst; }
            set { _userFirst = value; NotifyPropertyChanged(); }
        }
        private string _userSecond;

        public string UserSec
        {
            get { return _userSecond; }
            set { _userSecond = value; NotifyPropertyChanged(); }
        }

        public CompetitionViewModel()
        {
            SendData = new RelayCommand(o =>
            {
                MainWindowViewModel.names[0] = UserFirst;
                MainWindowViewModel.names[1] = UserSec;
                MainWindowViewModel.isState = true;
            });
        }
    }
}
