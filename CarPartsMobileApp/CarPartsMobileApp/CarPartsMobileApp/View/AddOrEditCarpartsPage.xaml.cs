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
        public AddOrEditCarpartsPage(Carpart carparts =null)
        {
            InitializeComponent();
            BindingContext = new AddOrEditCarPartsViewModel();
            if (carparts !=null)
            {
                ((AddOrEditCarPartsViewModel)BindingContext).CarPart= carparts;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Carpart carparts = ((AddOrEditCarPartsViewModel)BindingContext).CarPart;
            if (carparts.PartsId==0)
            {
                carparts.PictureUrl = "part.png";
            }

            MessagingCenter.Send(this, "AddOrEditPart", carparts);
            Navigation.PopAsync();
        }
    }
}