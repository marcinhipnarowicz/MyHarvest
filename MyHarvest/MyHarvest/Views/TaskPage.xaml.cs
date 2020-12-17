using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyHarvest.Models;
using MyHarvest.Views;
using MyHarvest.ViewModels;
using MyHarvest.Base;

namespace MyHarvest.Views
{
    public partial class TaskPage : ContentPage
    {
        private ItemsViewModel _viewModel;

        public TaskPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (LocalConfig.LoginModel.IdAccountType == 1)
            {
                //await Navigation.PushAsync(new AddTaskPage());
                await Shell.Current.GoToAsync("AddTaskPage");
            }
            else
            {
                await DisplayAlert("Uwaga!", "Nie masz uprawnień do dodawania zadań", "Ok");
            }
        }
    }
}