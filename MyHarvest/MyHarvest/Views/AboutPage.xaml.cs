using MyHarvest.Base;
using MyHarvest.Services;
using MyHarvest.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHarvest.Views
{
    public partial class AboutPage : ContentPage
    {
        private List<UserVm> _userVm;
        private EmployeeListVm _employeeList;

        public AboutPage()
        {
            _employeeList = new EmployeeListVm();
            InitializeComponent();
            Init();
            SetValueInListViewAsync();
        }

        protected virtual void Init()
        {
            BindingContext = _employeeList;
        }

        public async void SetValueInListViewAsync()
        {
            if (LocalConfig.LoginModel.IdAccountType == 1)
            {
                var data = await GetData();

                _userVm = data;
                _employeeList.Employees.Clear();
                lvTitleLabel.Text = "Lista pracowników";

                if (data.Count != 0)
                {
                    foreach (var item in data)
                    {
                        _employeeList.Employees.Add(item.FirstName + " " + item.Surname);
                    }
                }
                else
                {
                    _employeeList.Employees.Add("Nie posiadasz żadnych pracowników");
                }
            }
            else if (LocalConfig.LoginModel.IdAccountType == 2)
            {
                var data = await GetBossFormUser();

                _employeeList.Employees.Clear();
                lvTitleLabel.Text = "Twój szef to:";

                if (data != null)
                {
                    _employeeList.Employees.Add(data.FirstName + " " + data.Surname);
                }
                else
                {
                    _employeeList.Employees.Add("Nie jesteś przypisany do żadnego szefa");
                }
            }
        }

        protected async virtual Task<List<UserVm>> GetData()
        {
            List<UserVm> data = new List<UserVm>();

            data = await UserService.GeUserFromBossList(LocalConfig.LoginModel.Id);//dodać pobieranie id zalogowanego użytkownika

            return data;
        }

        protected async virtual Task<UserVm> GetBossFormUser()
        {
            UserVm boss = new UserVm();

            boss = await UserService.GetBossFormUser(LocalConfig.LoginModel.Id);

            return boss;
        }

        private void mapsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapPage());
        }
    }
}