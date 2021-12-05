using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CarPartsMobileApp.Data;
using CarPartsMobileApp.Droid.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidNetworkConnection))]

namespace CarPartsMobileApp.Droid.Data
{
    public class AndroidNetworkConnection : INetworkConn
    {
        public bool IsConnected { get; set; }

        [Obsolete]
        public void checkNetwConn()
        {
            ConnectivityManager connmanager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            NetworkInfo activenetworkInfo = connmanager.ActiveNetworkInfo;
            if (activenetworkInfo!=null)
            {
                IsConnected = true;
            }
            else
            {
                IsConnected = false;
            }
        }
    }
}