using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CarPartsMobileApp.ViewModel.Base
{
   public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
