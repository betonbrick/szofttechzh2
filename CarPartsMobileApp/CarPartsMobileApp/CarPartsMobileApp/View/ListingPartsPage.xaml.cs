using CarPartsMobileApp.Model;
using CarPartsMobileApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarPartsMobileApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListingPartsPage : ContentPage
    {
        public ListingPartsPage()
        {
            InitializeComponent();
            BindingContext = new CarPartsListViewModel();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddOrEditCarpartsPage());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;
            CarPartsModel carPartsmodel = ((CarPartsListViewModel)BindingContext).CarParts.Where(cp => cp.PartsId == (int)tappedEventArgs.Parameter).FirstOrDefault();
            Navigation.PushAsync(new AddOrEditCarpartsPage(carPartsmodel));
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;
            CarPartsModel carPartsmodel = ((CarPartsListViewModel)BindingContext).CarParts.Where(cp => cp.PartsId == (int)tappedEventArgs.Parameter).FirstOrDefault();
            ((CarPartsListViewModel)BindingContext).CarParts.Remove(carPartsmodel);
        }

       
    }
}