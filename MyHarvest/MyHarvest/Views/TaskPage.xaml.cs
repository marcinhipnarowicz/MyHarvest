using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyHarvest.Views;
using MyHarvest.ViewModels;
using MyHarvest.Base;
using MyHarvest.Services;

namespace MyHarvest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {
        protected TaskListVm _taskList;
        private List<UserInformationVm> _userInformation;
        private int disappearingTabIndex;
        private int appearingIndex;
        private bool isEmployee;

        public TaskPage()
        {
            InitializeComponent();
            _taskList = new TaskListVm();

            BindingContext = _taskList;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SetData();
            Init();
        }

        private void Init()
        {
            if (LocalConfig.LoginModel.IdAccountType == 2)
            {
                isEmployee = true;
                ToolbarItem.Text = "";
            }
        }

        private async void SetData()
        {
            await Task.Run(async () =>
            {
                var data = await GetData();

                _userInformation = data;

                _taskList.UserInformations.Clear();

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        _taskList.UserInformations.Add(item);
                    }
                }
            });
        }

        protected async virtual Task<List<UserInformationVm>> GetData()
        {
            List<UserInformationVm> data = new List<UserInformationVm>();
            if (LocalConfig.LoginModel.IdAccountType == 2)
            {
                data = await UserInformationService.GetUserInformationListForEmployee(LocalConfig.LoginModel.Id);
            }
            else if (LocalConfig.LoginModel.IdAccountType == 1)
            {
                data = await UserInformationService.GetUserInformationListForBoss(LocalConfig.LoginModel.Id);
            }

            return data;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (isEmployee == false)
            {
                await Shell.Current.GoToAsync("AddEditTaskPage");
            }
        }

        private void TasksListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var element = e.Item as UserInformationVm;

            if (disappearingTabIndex > appearingIndex)
            {
                var index = disappearingTabIndex;
                //numberOfElements.Text = index + "/" + _taskList.Tasks.Count();
            }
            else
            {
                var index = _taskList.UserInformations.IndexOf(element) + 1;
                //numberOfElements.Text = index + "/" + _taskList.Tasks.Count();
            }

            appearingIndex = _taskList.UserInformations.IndexOf(element) + 1;
        }

        private void TasksListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
            {
                var task = e.SelectedItem as UserInformationVm;

                await Navigation.PushAsync(new AddEditTaskPage(task));//w tym miejscu chyba zrobić w konstruktorze strony argument, żeby przekazywać do niej obiekt
            });
        }

        private void TasksListView_ItemDisappearing(object sender, ItemVisibilityEventArgs e)
        {
            var element = e.Item as UserInformationVm;
            disappearingTabIndex = _taskList.UserInformations.IndexOf(element) + 1;
        }
    }
}