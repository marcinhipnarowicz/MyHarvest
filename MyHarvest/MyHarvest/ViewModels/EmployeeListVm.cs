using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyHarvest.ViewModels
{
    public class EmployeeListVm
    {
        public ObservableCollection<string> Employees { get; set; }

        public EmployeeListVm()
        {
            Employees = new ObservableCollection<string>();
        }
    }
}