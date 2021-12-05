using CarPartsMobileApp.Model;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            BackgroundColor = Const.BackgrColor;
            lblusern.TextColor = Const.TxtColor;
            lblpwd.TextColor = Const.TxtColor;

            ActCirc.IsVisible = false;
            loginImage.HeightRequest = Const.LogoSize;
            App.CheckNetAtStart(lblnoint, this);
            entryUsern.Completed += (s, e) => entryPwd.Focus();
            entryPwd.Completed += (s, e) => lgnbtn_Clicked(s, e);
        }

        private async void lgnbtn_Clicked(object sender, EventArgs e)
        {
            loginUser user = new loginUser(entryUsern.Text, entryPwd.Text);
            if (user.checkEntries())
            {
                if (await App.InternetChecking())
                {
                    Tokenz result = await App.restAPIServi.login(user);

                    if (result!=null)
                    {
                        if (Device.RuntimePlatform==Device.Android)
                        {
                            Application.Current.MainPage = new NavigationPage(new ListingPartsPage());
                        }
                    }
                }
            }
            else
            {
                DisplayAlert("Bejelentkezés", "Rossz felhasználónév vagy jelszó!", "Oké");
            }
        }
    }
}