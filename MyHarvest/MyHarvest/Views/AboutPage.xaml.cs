using MyHarvest.Services;
using MyHarvest.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHarvest.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        public async void SetValueInListViewAsync()
        {
            List<UserVm> userVm = new List<UserVm>();
            userVm = await UserService.GeUserFromBossList();//pobrać wszystkich użytkowników dla danego szefa

            foreach (var item in userVm)
            {
                employeesListView.ItemsSource = item.FirstName + " " + item.Surname;
            }
        }

        private void mapsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapPage());
        }
    }
}