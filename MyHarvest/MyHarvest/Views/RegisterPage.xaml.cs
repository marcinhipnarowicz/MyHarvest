﻿using MyHarvest.Base;
using MyHarvest.Services;
using MyHarvest.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHarvest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);

            SetValueInPickerAsync();
        }

        public async void SetValueInPickerAsync()
        {
            List<AccountTypeVm> accountTypeVm = new List<AccountTypeVm>();
            accountTypeVm = await AccountTypeService.GetAccountTypeList();

            foreach (var item in accountTypeVm)
            {
                accountTypePicker.Items.Add(item.Name);
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

        private bool IsValidPassword(string text)
        {
            bool specialSymbolFlag = false;
            bool numberFlag = false;
            bool lowerLetterFlag = false;
            bool upperLetterFlag = false;
            bool quantityLetterFlag = false;

            if (IsContainSpecialSymbols(text))
            {
                specialSymbolFlag = true;
            }

            if (IsContainNumberSymbols(text))
            {
                numberFlag = true;
            }

            if (IsContainLowerLetterSymbols(text))
            {
                lowerLetterFlag = true;
            }

            if (IsContainUpperLetterSymbols(text))
            {
                upperLetterFlag = true;
            }

            if (IsValidQuantitySymbols(text))
            {
                quantityLetterFlag = true;
            }

            if (numberFlag && specialSymbolFlag && lowerLetterFlag && upperLetterFlag && quantityLetterFlag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsContainSpecialSymbols(string text)
        {
            string specialSymbols = "!@#$%^&*()_+={[}]|\'/?.>,<`:;'";

            for (int i = 0; i < specialSymbols.Length; i++)
            {
                if (text.Contains(specialSymbols[i]))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsContainNumberSymbols(string text)
        {
            string numberSymbols = "1234567890";

            for (int i = 0; i < numberSymbols.Length; i++)
            {
                if (text.Contains(numberSymbols[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsContainLowerLetterSymbols(string text)
        {
            string lowerLetterSymbols = "qwertyuiopasdfghjklzxcvbnm";

            for (int i = 0; i < lowerLetterSymbols.Length; i++)
            {
                if (text.Contains(lowerLetterSymbols[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsContainUpperLetterSymbols(string text)
        {
            string upperLetterSymbols = "QWERTYUIOPASDFGHJKLZXCVBNM";

            for (int i = 0; i < upperLetterSymbols.Length; i++)
            {
                if (text.Contains(upperLetterSymbols[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsValidQuantitySymbols(string text)
        {
            if (text.Length < 8)
            {
                return false;
            }
            return true;
        }

        private async void registerButton_Clicked(object sender, EventArgs e)
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
                    if (IsValidPassword(passwordEntry.Text))
                    {
                        if (passwordEntry.Text == confirmPasswordEntry.Text)
                        {
                            var userVm = new UserVm()
                            {
                                Email = emailEntry.Text,
                                Password = passwordEntry.Text,
                                FirstName = firstNameEntry.Text,
                                Surname = surnameEntry.Text,
                                IdAccountType = accountTypePicker.SelectedIndex + 1,
                                BossKey = bossKeyEntry.Text
                            };

                            var data = await UserService.Register(userVm);
                            if (data != null)
                            {
                                LocalConfig.UserModel = data;
                                await DisplayAlert("OK!", "Rejestracja powiodła się. Zaloguj się do swojego konta", "Ok");
                                await Shell.Current.GoToAsync("//LoginPage");
                            }
                            else
                            {
                                await DisplayAlert("Uwaga!", "Rejestracja nie powiodła się", "Ok");
                            }
                        }
                        else
                        {
                            await DisplayAlert("Uwaga!", "Hasła nie są identyczne", "Ok");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Uwaga!", "Hasło musi zawierac osiem znaków, jedną dużą i małą literę, jedną cyfrę i  jeden znak specjalny", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Uwaga!", "Niepoprawny adres email", "Ok");
                }
            }
        }

        private void AccountTypePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex == 0)
            {
                bossKeyEntry.IsVisible = false;
            }

            if (selectedIndex == 1)
            {
                bossKeyEntry.IsVisible = true;
            }
        }
    }
}