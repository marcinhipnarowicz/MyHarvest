using MyHarvest.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace MyHarvest.Services
{
    public static class BaseService
    {
        public static bool InternetConnection()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                {
                    ToastMessage.ShowToastError("Brak połączenia z internetem");
                });

                return false;
            }
            else
                return true;
        }
    }
}