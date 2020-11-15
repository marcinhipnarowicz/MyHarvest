using Microsoft.WindowsAzure.MobileServices;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHarvestMobile
{
    public partial class App : Application
    {
        public static MobileServiceClient client = new MobileServiceClient("https://myharvestapp.azurewebsites.net");

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#6eaa5e")
                //#20991a
            };
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