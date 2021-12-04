using CarPartsMobileApp.Model;
using CarPartsMobileApp.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPartsMobileApp.ViewModel
{
    public class AddOrEditCarPartsViewModel : BaseViewModel
    {
       public CarPartsModel CarParts { get; set; }
       public AddOrEditCarPartsViewModel() 
        {
            CarParts = new CarPartsModel();
        }
    }
}
