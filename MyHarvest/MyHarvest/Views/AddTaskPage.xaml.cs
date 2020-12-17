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
    public partial class AddTaskPage : ContentPage
    {
        private List<UserVm> _userVm;
        private EmployeeListVm _employeeList;

        public AddTaskPage()
        {
            InitializeComponent();
            //SetValueInPickerAsync();
            //SetValueInListViewAsync();
            Init();
        }

        public async void Init()
        {
            var data = await GetData();
            _userVm = data;

            //employeesStackLayout.Children.Add(a);

            employeesStackLayout.Orientation = StackOrientation.Vertical;

            if (data != null)
            {
                foreach (var item in data)
                {
                    var label = new Label();
                    var checkbox = new CheckBox();
                    StackLayout stackLayoutLine = new StackLayout();

                    employeesStackLayout.Children.Add(stackLayoutLine);
                    stackLayoutLine.Orientation = StackOrientation.Horizontal;

                    label.Text = item.FirstName + " " + item.Surname;

                    stackLayoutLine.Children.Add(label);
                    stackLayoutLine.Children.Add(checkbox);
                }
            }
            else
            {
                employeesStackLayout.Children.Add(new Label { Text = "Nie posiadasz żadnych pracowników" });
            }
        }

        public async void SetValueInPickerAsync()
        {
            List<StatusOfTaskVm> statusOfTaskVm = new List<StatusOfTaskVm>();
            statusOfTaskVm = await StatusOfTaskService.GetStatusOfTaskList();

            foreach (var item in statusOfTaskVm)
            {
                //statusOfTaskPicker.Items.Add(item.Name);
            }
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
            else
            {
                _employeeList.Employees.Add("Nie posiadasz żadnych pracowników");
            }
        }

        protected async virtual Task<List<UserVm>> GetData()
        {
            List<UserVm> data = new List<UserVm>();

            data = await UserService.GeUserFromBossList(LocalConfig.LoginModel.Id);//dodać pobieranie id zalogowanego użytkownika

            return data;
        }

        private void StatusOfTaskPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
        }

        private void employeesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectEmployee = e.SelectedItem as EmployeeListVm;
        }
    }
}