using CarPartsMobileApp.Model;
using CarPartsMobileApp.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPartsMobileApp.ViewModel
{
    public class AddOrEditCarPartsViewModel : BaseViewModel
    {
       public Carpart CarPart { get; set; }
       public AddOrEditCarPartsViewModel() 
        {
            CarPart = new Carpart();
        }
    }
}
