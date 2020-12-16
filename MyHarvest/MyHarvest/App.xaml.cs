using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyHarvest.Services;
using MyHarvest.Views;

namespace MyHarvest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            //MainPage = new LoginPage();
            //{
            //    BarBackgroundColor = Color.FromHex("#6eaa5e")
            //    //#20991a
            //};
            //MainPage = new NavigationPage(new LoginPage());
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