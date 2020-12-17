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
                    var checkbox = new CheckBox();
                    StackLayout stackLayoutLine = new StackLayout();

                    employeesStackLayout.Children.Add(stackLayoutLine);
                    stackLayoutLine.Orientation = StackOrientation.Horizontal;

                    label.Text = item.FirstName + " " + item.Surname;

                    stackLayoutLine.Children.Add(checkbox);
                    stackLayoutLine.Children.Add(label);
                }
            }
            else
            {
                employeesStackLayout.Children.Add(new Label { Text = "Nie posiadasz żadnych pracowników", TextColor = Color.Red }); ;
            }

            //var check = new CheckBox();
            //var labelTap = new TapGestureRecognizer();
            //labelTap.Tapped += (s, e) =>
            //{
            //};
            //var label1 = new Label();
            //label1.GestureRecognizers.Add(labelTap);
        }

        private void OnCheckBoxcheckBox(object sender, CheckedChangedEventArgs e)
        {
        }

        protected async virtual Task<List<UserVm>> GetData()
        {
            List<UserVm> data = new List<UserVm>();

            data = await UserService.GeUserFromBossList(LocalConfig.LoginModel.Id);//dodać pobieranie id zalogowanego użytkownika

            return data;
        }
    }
}