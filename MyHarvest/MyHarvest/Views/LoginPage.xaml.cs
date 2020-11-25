﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHarvest.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHarvest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private bool IsValidEmail(string text)
        {
            char symbol = '@';

            int position = text.IndexOf(symbol);

            if (position == -1 || position == 0 || position == text.Length)
            {
                return false;
            }

            return true;
        }

        private void registerUserButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            if (IsValidEmail(emailEntry.Text))
            {
                await Shell.Current.GoToAsync("//AboutPage");
            }
            else
            {
                message.Text = "Niepoprawny adres email";
                message.IsVisible = true;
            }
        }
    }
}