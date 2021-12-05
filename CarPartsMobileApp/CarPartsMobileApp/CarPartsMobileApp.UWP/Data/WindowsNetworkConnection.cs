using CarPartsMobileApp.Data;
using CarPartsMobileApp.UWP.Data;
using Windows.Networking.Connectivity;
using Xamarin.Forms;
[assembly: Xamarin.Forms.Dependency(typeof(WindowsNetworkConnection))]

namespace CarPartsMobileApp.UWP.Data
{

    class WindowsNetworkConnection : INetworkConn
    {
        public bool IsConnected { get; set; }

        public void checkNetwConn()
        {
            
        }
    }
}
