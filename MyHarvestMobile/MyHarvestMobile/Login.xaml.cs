using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyHarvestMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
        }

        private void registerUserButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());//Aby nawigowac trzeba dodac nawigator w App.cs
        }
    }
}