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
    }
}