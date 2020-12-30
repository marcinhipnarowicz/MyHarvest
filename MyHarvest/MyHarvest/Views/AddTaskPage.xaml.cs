using Acr.UserDialogs;
using MyHarvest.Base;
using MyHarvest.Services;
using MyHarvest.Services.Enum;
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
        private int idTask;

        public AddTaskPage()
        {
            InitializeComponent();
            Init();
        }

        public AddTaskPage(UserInformationVm userInformationVm)
        {
            idTask = (int)userInformationVm.IdTask;
            InitializeComponent();
            InitEdit(userInformationVm);
        }

        public void InitEdit(UserInformationVm userInformationVm)
        {
            if (LocalConfig.LoginModel.IdAccountType == (int)AccountType.Boss)
            {
                taskForEditor.IsVisible = true;
                addButton.IsVisible = true;
                deleteButton.IsVisible = true;

                taskNameEditor.Text = userInformationVm.TaskName;
                taskDescriptionEditor.Text = userInformationVm.TaskDescripton;
                taskAreaEditor.Text = userInformationVm.Area;
                taskForEditor.Text = userInformationVm.UserFullName;
            }
            else if (LocalConfig.LoginModel.IdAccountType == (int)AccountType.Employee)
            {
                addButton.IsVisible = true;
                taskForLabel.IsVisible = false;
                employeesStackLayout.IsVisible = false;
                taskNameEditor.IsReadOnly = true;
                taskDescriptionEditor.IsReadOnly = true;

                taskNameEditor.Text = userInformationVm.TaskName;
                taskDescriptionEditor.Text = userInformationVm.TaskDescripton;
                taskAreaEditor.Text = userInformationVm.Area;
            }
        }

        public async void Init()
        {
            if (LocalConfig.LoginModel.IdAccountType == (int)AccountType.Boss)
            {
                addButton.IsVisible = true;
            }
            else if (LocalConfig.LoginModel.IdAccountType == (int)AccountType.Employee)
            {
                addButton.IsVisible = false;
                taskForLabel.IsVisible = false;
            }

            slider.IsVisible = false;
            statusLabel.IsVisible = false;
            statusOfTaskLabel.IsVisible = false;

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

        private async void addButton_Clicked(object sender, EventArgs e)
        {
            bool isTaskNameEditor = string.IsNullOrEmpty(taskNameEditor.Text);
            List<int> IdEmployeesList = GetCheckEmployees();

            if (IdEmployeesList.Count != 0)
            {
                if (isTaskNameEditor)
                {
                    await DisplayAlert("Uwaga!", "Nazwa zadania jest pusta", "Ok");
                }
                else
                {
                    var taskVm = new TaskVm()
                    {
                        Name = taskNameEditor.Text,
                        Description = taskDescriptionEditor.Text
                    };

                    var data = await TaskService.AddTask(taskVm);

                    if (IdEmployeesList.Count == 0)
                    {
                        await DisplayAlert("Uwaga!", "Nie wybrałeś pracownika do wykonania zadania", "Ok");
                    }
                    else
                    {
                        foreach (var item in IdEmployeesList)
                        {
                            var userInformationVm = new UserInformationVm
                            {
                                IdUser = item,
                                IdTask = data.IdTask,
                                Area = taskAreaEditor.Text,
                                IdTaskStatus = 1
                            };

                            var userTaskVm = new UserTaskVm
                            {
                                IdTask = data.IdTask,
                                IdUser = LocalConfig.LoginModel.Id
                            };

                            UserInformationService.AddUserInformation(userInformationVm);
                            UserTaskService.AddUserTask(userTaskVm);
                            await DisplayAlert("OK!", "Pomyślnie dodano zadania!", "Ok");
                            await Shell.Current.GoToAsync("..");//cofajnie do poprzedniej strony
                        }
                    }
                }
            }
            else
            {
                await DisplayAlert("Uwaga!", "Nie wybrałeś pracownika do wykonania zadania", "Ok");
            }
        }

        private async void deleteButton_Clicked(object sender, EventArgs e)
        {
            if (await UserDialogs.Instance.ConfirmAsync("Czy na pewno chcesz usunąć zadanie?", "Potwierdź", "Tak", "Anuluj"))
            {
                TaskService.RemoveTask(idTask);

                await DisplayAlert("Potwierdzenie", "Zadanie zostało usunięte", "Ok");
                await Navigation.PushAsync(new TaskPage());
            }
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)Math.Round(e.NewValue);
            slider.Value = value;

            if (value == 0)
            {
                statusLabel.Text = "Do zrobienia";
                slider.ThumbColor = Color.Red;
                slider.MinimumTrackColor = Color.Red;
            }
            else if (value == 1)
            {
                statusLabel.Text = "W realizacji";
                slider.ThumbColor = Color.Yellow;
                slider.MinimumTrackColor = Color.Yellow;
            }
            else if (value == 2)
            {
                statusLabel.Text = "Wykonane";
                slider.ThumbColor = Color.Green;
                slider.MinimumTrackColor = Color.Green;
            }
        }
    }
}