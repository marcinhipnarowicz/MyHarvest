using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHarvestMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private void registerButton_Clicked(object sender, EventArgs e)
        {
            if (passwordEntry.Text == confirmPasswordEntry.Text)
            {
            }
            else
            {
                DisplayAlert("Error", "Hasła nie są identyczne", "Ok");
            }
        }
    }
}