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
            var data = await GetData();

            _userVm = data;
            _employeeList.Employees.Clear();

            if (data != null)
            {
                foreach (var item in data)
                {
                    _employeeList.Employees.Add(item.FirstName + " " + item.Surname);
                }
            }

            //List<UserVm> userVm = new List<UserVm>();
            ////userVm = await UserService.GeUserFromBossList();//pobrać wszystkich użytkowników dla danego szefa

            //userVm = await UserService.GeUserFromBossList(54);

            ////employeesListView.ItemsSource = new string[] { "marcin H", "mmmm aaaa" };

            //foreach (var item in userVm)
            //{
            //    employeesListView.ItemsSource = new string[] { item.FirstName + " " + item.Surname };
            //}
        }

        protected async virtual Task<List<UserVm>> GetData()
        {
            List<UserVm> data = new List<UserVm>();

            data = await UserService.GeUserFromBossList(54);

            return data;
        }

        private void mapsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapPage());
        }
    }
}