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
    public partial class AddOrEditCarpartsPage : ContentPage
    {
        public AddOrEditCarpartsPage(CarPartsModel carPartsModel =null)
        {
            InitializeComponent();
            BindingContext = new AddOrEditCarPartsViewModel();
            if (carPartsModel !=null)
            {
                ((AddOrEditCarPartsViewModel)BindingContext).CarParts= carPartsModel;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            CarPartsModel carPartsModel = ((AddOrEditCarPartsViewModel)BindingContext).CarParts;
            if (carPartsModel.PartsId==0)
            {
                carPartsModel.PictureUrl = "part.png";
            }

            MessagingCenter.Send(this, "AddOrEditPart", carPartsModel);
            Navigation.PopAsync();
        }
    }
}