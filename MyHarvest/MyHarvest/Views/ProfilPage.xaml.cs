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
                BossKeyLabel.Text = "Hasło dostępu do Twojej brygady";
                BossKeyEntry.Placeholder = "";
                BossKeyEntry.IsReadOnly = true;
                GetData();
            }
            else if (LocalConfig.LoginModel.IdAccountType == 2)
            {
                BossKeyEntry.Text = "";
                if (GetData().Result.IdBoss != null)
                {
                    DeleteBossButton.IsVisible = true;
                }
                else
                {
                    DeleteBossButton.IsVisible = false;
                    AddBossButton.IsVisible = true;
                }
            }
        }

        protected async virtual Task<UserVm> GetData()
        {
            UserVm worker = new UserVm();

            worker = await UserService.GetUser(LocalConfig.LoginModel.Email);

            FirstNameEntry.Text = worker.FirstName;
            SurnameEntry.Text = worker.Surname;
            BossKeyEntry.Text = worker.BossKey;

            return worker;
        }

        private async void DeleteBossButton_Clicked(object sender, EventArgs e)
        {
            if (await UserDialogs.Instance.ConfirmAsync("Czy na pewno chcesz opuścić brygadę szefa?", "Potwierdź", "Tak", "Anuluj"))
            {
                UserService.RemoveBossOfEmployee(LocalConfig.LoginModel.Id);

                await DisplayAlert("Potwierdzenie", "Nie należysz już do szefa", "Ok");
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

        private async void AddBossButton_Clicked(object sender, EventArgs e)
        {
            if (BossKeyEntry.Text != null)
            {
                var userVm = new UserVm()
                {
                    Id = LocalConfig.LoginModel.Id,
                    BossKey = BossKeyEntry.Text
                };

                await UserService.AddNewBossForEmployee(userVm, LocalConfig.LoginModel.Id);
                await DisplayAlert("Ok!", "Dodano nowego szefa", "Ok");
            }
            else
            {
                await DisplayAlert("Błąd!", "Nie istnieje szef o wprowadzonyn kodzie", "Ok");
            }
        }
    }
}