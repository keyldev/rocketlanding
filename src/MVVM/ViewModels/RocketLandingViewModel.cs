using mvvm_rocketlanding.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_rocketlanding.MVVM.ViewModels
{
    class RocketLandingViewModel : ObservableObject
    {

        private float _rocketPosition;

        public float RocketPosition
        {
            get { return _rocketPosition; }
            set { _rocketPosition = value; NotifyPropertyChanged(); }
        }
        private int _gameWindowHeight;

        public int GameWindowHeight
        {
            get { return _gameWindowHeight; }
            set { _gameWindowHeight = value; NotifyPropertyChanged(); }
        }

        public RocketLandingViewModel()
        {

        }
    }
}
