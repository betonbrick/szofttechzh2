using System;
using System.Collections.Generic;
using System.Text;

namespace CarPartsMobileApp.Data
{
    public interface INetworkConn
    {
        bool IsConnected { get; }
        void checkNetwConn();
    }
}
