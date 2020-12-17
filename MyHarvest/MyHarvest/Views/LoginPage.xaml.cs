using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHarvest.Base;
using MyHarvest.Services;
using MyHarvest.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHarvest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private bool isTest = true;

        public LoginPage()
        {
            InitializeComponent();
            if (isTest)
            {
                emailEntry.Text = "t1@op.pl";
                passwordEntry.Text = "marcin";
            }
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

        private async void registerUserButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
            //await Navigation.PushAsync(new AddTaskPage());
        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEntry = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEntry = string.IsNullOrEmpty(passwordEntry.Text);

            if (isEmailEntry || isPasswordEntry)
            {
                await DisplayAlert("Uwaga!", "Adres email lub hasło nie zostały wprowadzone", "Ok");
            }
            else
            {
                if (IsValidEmail(emailEntry.Text))
                {
                    var loginVm = new LoginVm()
                    {
                        Email = emailEntry.Text,
                        Password = passwordEntry.Text
                    };

                    var data = await UserService.Login(loginVm);
                    if (data != null)
                    {
                        LocalConfig.LoginModel = data;
                        await Shell.Current.GoToAsync("//AboutPage");
                    }
                    else
                    {
                        await DisplayAlert("Uwaga!", "Logowanie nie powiodło się", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Uwaga!", "Niepoprawny adres email", "Ok");
                    //message.Text = "Niepoprawny adres email";
                    //message.IsVisible = true;
                }
            }
        }
    }
}