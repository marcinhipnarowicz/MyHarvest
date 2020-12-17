using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyHarvest.Services
{
    public class EmployeeItemList
    {
        public CheckBox Checkbox { get; set; }

        public Label Label { get; set; }

        public int IdEmployee { get; set; }

        public EmployeeItemList()
        {
            Checkbox = new CheckBox();
            Label = new Label() { FontSize = 17 };
        }
    }
}