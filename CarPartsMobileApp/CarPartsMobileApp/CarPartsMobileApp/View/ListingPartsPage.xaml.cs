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
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}