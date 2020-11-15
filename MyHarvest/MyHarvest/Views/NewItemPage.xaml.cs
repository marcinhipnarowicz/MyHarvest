using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyHarvest.Models;
using MyHarvest.ViewModels;

namespace MyHarvest.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        //public List<Users> Users { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}