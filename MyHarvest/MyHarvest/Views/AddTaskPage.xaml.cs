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
        private List<UserVm> _userVm = new List<UserVm>();
        private List<EmployeeItemList> _employeeCheckBoxList = new List<EmployeeItemList>();

        public AddTaskPage()
        {
            InitializeComponent();
            Init();
        }

        public async void Init()
        {
            var data = await GetData();
            _userVm = data;

            employeesStackLayout.Orientation = StackOrientation.Vertical;

            if (data != null)
            {
                foreach (var item in data)
                {
                    var label = new Label() { FontSize = 17 };
                    var employeeItemList = new EmployeeItemList();

                    StackLayout stackLayoutLine = new StackLayout();

                    employeesStackLayout.Children.Add(stackLayoutLine);
                    stackLayoutLine.Orientation = StackOrientation.Horizontal;

                    employeeItemList.Label.Text = item.FirstName + " " + item.Surname;

                    employeeItemList.IdEmployee = item.Id;
                    stackLayoutLine.Children.Add(employeeItemList.Checkbox);
                    stackLayoutLine.Children.Add(employeeItemList.Label);

                    _employeeCheckBoxList.Add(employeeItemList);
                }
            }
            else
            {
                employeesStackLayout.Children.Add(new Label { Text = "Nie posiadasz żadnych pracowników", TextColor = Color.Red }); ;
            }

            var check = new CheckBox();

            var labelTap = new TapGestureRecognizer();
            labelTap.Tapped += (s, e) =>
            {
            };
            var label1 = new Label();
            label1.GestureRecognizers.Add(labelTap);
        }

        protected async virtual Task<List<UserVm>> GetData()
        {
            List<UserVm> data = new List<UserVm>();

            data = await UserService.GeUserFromBossList(LocalConfig.LoginModel.Id);//dodać pobieranie id zalogowanego użytkownika

            return data;
        }

        public List<int> GetCheckEmployees()
        {
            List<int> result = new List<int>();

            foreach (var item in _employeeCheckBoxList)
            {
                if (item.Checkbox.IsChecked)
                {
                    result.Add(item.IdEmployee);
                }
            }

            return result;
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {
            GetCheckEmployees();
        }
    }
}