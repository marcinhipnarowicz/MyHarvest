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

        private void DeleteBossButton_Clicked(object sender, EventArgs e)
        {
            if (!passwordEntry.IsVisible)
            {
                passwordEntry.IsVisible = true;
                confirmPasswordEntry.IsVisible = true;
            }
            else
            {
            }
        }

        private async void changePasswordButton_Clicked(object sender, EventArgs e)
        {
            if (await UserDialogs.Instance.ConfirmAsync("Czy na pewno chcesz opuścić brygadę szefa?", "Potwierdź", "Tak", "Anuluj"))
            {
                UserService.RemoveBossOfEmployee(LocalConfig.LoginModel.Id);
            }
        }
    }
}