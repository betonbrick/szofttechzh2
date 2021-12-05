using CarPartsMobileApp.Data;
using CarPartsMobileApp.Model;
using CarPartsMobileApp.View;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarPartsMobileApp
{
    public partial class App : Application
    {
        static TokenzDBController tokenzDB;
        static UserDBController userDB;

        static RestAPIService restAPIService;

        private static bool noInterSh;
        private static Timer timer;
        private static Label labelscrnn;
        private static bool haveNet;
        private static Page currentPage;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
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

        public static TokenzDBController TokenzDB 
        {
            get 
            {
                if (tokenzDB ==null)
                {
                    tokenzDB = new TokenzDBController();
                }
                return tokenzDB;
            }
        }
        public static UserDBController UserDB 
        {
            get 
            {
                if (userDB == null)
                {
                    userDB = new UserDBController();
                }
                return userDB;
            }
        }
        public static RestAPIService restAPIServi 
        {
            get 
            {
                if (restAPIService==null)
                {
                    restAPIService = new RestAPIService();
                }

                return restAPIService;
            }
        }
        private static void CheckNetIfTimeOver() 
        {
            var IntConn = DependencyService.Get<INetworkConn>();
            IntConn.checkNetwConn();
            if (!IntConn.IsConnected)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (haveNet)
                    {
                        if (!noInterSh)
                        {
                            haveNet = false;
                            labelscrnn.IsVisible = true;
                            await AlertMessage();
                        }
                    }
                }
                );
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    haveNet = true;
                    labelscrnn.IsVisible = false; 
                }
                );
            }
        }

        public static void CheckNetAtStart(Label label, Page page) 
        {
            labelscrnn = label;
            labelscrnn.Text = Const.nonetwork;
            labelscrnn.IsVisible = false;
            currentPage = page;
            haveNet = true;

            if (timer == null)
            {
                timer = new Timer((e) => { CheckNetIfTimeOver(); }, null, 70, (int)TimeSpan.FromSeconds(70).TotalMilliseconds);
            }
        }

        private static async Task AlertMessage() 
        {
            noInterSh = false;
            await currentPage.DisplayAlert("Kapcsolódás", "Az eszköz nem csatlakozik az internethez. Próbálja újra", "Oké");
            noInterSh = false;
        }

        public static async Task<bool> InternetChecking() 
        {
            var IntConn = DependencyService.Get<INetworkConn>();
            IntConn.checkNetwConn();

            if (!IntConn.IsConnected)
            {
                if (!noInterSh)
                {
                    await AlertMessage();
                }
                return false;
            }
            return true;
        }
    }
}
