using Acr.UserDialogs;
using MyHarvest.Base;
using MyHarvest.Services;
using MyHarvest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHarvest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilPage : ContentPage
    {
        public ProfilPage()
        {
            InitializeComponent();
            GetData();
            SetData();
        }

        private void SetData()
        {
            if (LocalConfig.LoginModel.IdAccountType == 1)
            {
            }
            else if (LocalConfig.LoginModel.IdAccountType == 2)
            {
                DeleteBossButton.IsVisible = true;
            }
        }

        protected async virtual void GetData()
        {
            UserVm worker = new UserVm();

            worker = await UserService.GetUser(LocalConfig.LoginModel.Email);

            FirstNameEntry.Text = worker.FirstName;
            SurnameEntry.Text = worker.Surname;
        }

        private async void DeleteBossButton_Clicked(object sender, EventArgs e)
        {
            if (await UserDialogs.Instance.ConfirmAsync("Czy na pewno chcesz opuścić brygadę szefa?", "Potwierdź", "Tak", "Anuluj"))
            {
                UserService.RemoveBossOfEmployee(LocalConfig.LoginModel.Id);
            }
        }

        private async void changePasswordButton_Clicked(object sender, EventArgs e)
        {
            if (!passwordEntry.IsVisible)
            {
                passwordEntry.IsVisible = true;
                confirmPasswordEntry.IsVisible = true;
            }
            else
            {
                if (passwordEntry.Text == confirmPasswordEntry.Text)
                {
                    var userVm = new UserVm()
                    {
                        Password = passwordEntry.Text
                    };

                    //metoda z UserService, która zmieni hasło w bazie
                }
                else
                {
                    await DisplayAlert("Uwaga!", "Hasła nie są identyczne", "Ok");
                }
            }
        }
    }
}