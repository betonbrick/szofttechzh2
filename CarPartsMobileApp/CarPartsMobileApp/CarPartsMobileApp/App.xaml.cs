using CarPartsMobileApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarPartsMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListingPartsPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
