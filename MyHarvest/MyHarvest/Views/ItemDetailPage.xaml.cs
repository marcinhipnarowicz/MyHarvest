using System.ComponentModel;
using Xamarin.Forms;
using MyHarvest.ViewModels;

namespace MyHarvest.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}