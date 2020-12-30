using System;
using System.Collections.Generic;
using MyHarvest.ViewModels;
using MyHarvest.Views;
using Xamarin.Forms;

namespace MyHarvest
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Navigation.PushAsync(new LoginPage());
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AddEditTaskPage), typeof(AddEditTaskPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}