using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Toast;
using Plugin.Toast.Abstractions;

namespace MyHarvest.Base
{
    public static class ToastMessage
    {
        public static void ShowToastSuccess(string message, ToastLength toastLength = ToastLength.Short)
        {
            CrossToastPopUp.Current.ShowToastSuccess(message, toastLength);
        }

        public static void ShowToastError(string message, ToastLength toastLength = ToastLength.Short)
        {
            CrossToastPopUp.Current.ShowToastError(message, toastLength);
        }

        public static void ShowToastWarning(string message, ToastLength toastLength = ToastLength.Short)
        {
            CrossToastPopUp.Current.ShowToastWarning(message, toastLength);
        }
    }
}