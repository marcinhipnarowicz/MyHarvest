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
        public AddTaskPage()
        {
            InitializeComponent();
            SetValueInPickerAsync();
        }

        public async void SetValueInPickerAsync()
        {
            List<StatusOfTaskVm> statusOfTaskVm = new List<StatusOfTaskVm>();
            statusOfTaskVm = await StatusOfTaskService.GetStatusOfTaskList();

            foreach (var item in statusOfTaskVm)
            {
                statusOfTaskPicker.Items.Add(item.Name);
            }
        }

        private void StatusOfTaskPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
        }
    }
}