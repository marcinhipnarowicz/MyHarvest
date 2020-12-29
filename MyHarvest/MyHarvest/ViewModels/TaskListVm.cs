using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyHarvest.ViewModels
{
    public class TaskListVm : INotifyPropertyChanged
    {
        public ObservableCollection<UserInformationVm> UserInformations { get; set; }

        public ObservableCollection<UserVm> Users { get; set; }

        public TaskListVm()
        {
            UserInformations = new ObservableCollection<UserInformationVm>();
            Users = new ObservableCollection<UserVm>();
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Implementation
    }
}