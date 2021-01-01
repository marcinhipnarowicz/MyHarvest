using Acr.UserDialogs;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Position = Plugin.Geolocator.Abstractions.Position;

namespace MyHarvest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private bool hasLocationPermission = false;
        private List<Pin> _pinList = new List<Pin>();
        private Pin _pin;

        private bool isEdited = false;

        public MapPage()
        {
            InitializeComponent();
            GetPermissions();
        }

        private void DrawPolyline()
        {
            locationsMap.MapElements.Clear();

            Polyline polyline = new Polyline
            {
                StrokeColor = Color.Red,
                StrokeWidth = 20
            };
            foreach (var item in _pinList)
            {
                polyline.Geopath.Add(item.Position);
                locationsMap.MapElements.Add(polyline);

                //item.MarkerClicked += async (s, args) =>
                //{
                //    args.HideInfoWindow = true;
                //    string pinName = ((Pin)s).Label;
                //    await DisplayAlert("Pin Clicked", $"{pinName} was clicked.", "Ok");
                //};
            }
            {
                //Polyline polyline = new Polyline
                //{
                //    StrokeColor = Color.Red,
                //    StrokeWidth = 20,

                //    Geopath =
                //    {
                //        new Xamarin.Forms.Maps.Position(50.6631001, 17.9031356),
                //        new Xamarin.Forms.Maps.Position(50.6631200, 17.9031356),
                //        new Xamarin.Forms.Maps.Position(50.6631091, 17.9041398)
                //    }
                //};
                ////polyline.Geopath.Add(new Xamarin.Forms.Maps.Position(50.6631001, 17.9031356));
                //locationsMap.MapElements.Add(polyline);// add the polyline to the map's MapElements collection

                //Pin pin = new Pin
                //{
                //    Label = "cos",
                //    Type = PinType.Place,
                //    Position = new Xamarin.Forms.Maps.Position(50.6631001, 17.9031356)
                //};
                //locationsMap.Pins.Add(pin);
            }
        }

        private async void GetPermissions() //ustalanie lokalizacji z zezwoleniem, potrzeba dodania Plugin.Permissions
        {
            try
            {
                //var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationWhenInUsePermission>();
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Lokalizacja", "Potrzeba użyć lokalizacji", "Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                    if (results.ContainsKey(Permission.LocationWhenInUse))
                        status = results[Permission.LocationWhenInUse];
                }

                if (status == PermissionStatus.Granted)
                {
                    hasLocationPermission = true;
                    locationsMap.IsShowingUser = true;
                    GetLocation();
                }
                else
                {
                    await DisplayAlert("Błąd lokalizacji", "Brak zezwolenia na udostępnienie lokalizacji", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;

                locator.PositionChanged += Locator_PositionChanged;

                await locator.StartListeningAsync(TimeSpan.Zero, 2);// to ustawia mapę na aktualną pozycję podczas przemieszczania się
            }
            GetLocation();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        private async void GetLocation() //akutalna lokalizacja, wymagała dodania pakietu Xam.Plugin.Geolocator
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                MoveMap(position);
            }
        }

        private void MoveMap(Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 0.01, 0.01);//0.01  1 - oznacza ile stóp w lewo i w góre ustawia się mapa od lokalizacji
            locationsMap.MoveToRegion(span);
        }

        private void locationsMap_MapClicked(object sender, MapClickedEventArgs e)
        {
            if (!isEdited)
            {
                Pin pin = new Pin
                {
                    Label = "punkt",
                    Type = PinType.Place,
                    Position = e.Position
                };

                pin.MarkerClicked += (s, args) =>
                {
                    ClickedPin(pin);
                };

                locationsMap.Pins.Add(pin);
                _pinList.Add(pin);
                DrawPolyline();
            }
            else
            {
                _pin.Position = e.Position;
                isEdited = false;
                DrawPolyline();
            }
        }

        private void ClickedPin(Pin pin)
        {
            _pin = pin;
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            if (_pin != null)
            {
                isEdited = true;
                await DisplayAlert("Informacja", "Wybierz nowe miejsce na mapie, w którym chcesz umieścić punkt.", "Ok");
            }
            else
            {
                await DisplayAlert("Uwaga!", "Wybierz punkt, który chcesz edytować. Jeśli nie istnieje, dodaj go, klikając na mapę.", "Ok");
            }
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (_pin != null)
            {
                _pinList.Remove(_pin);
                _pin.Position = new Xamarin.Forms.Maps.Position(100, 100);
                DrawPolyline();
            }
            else
            {
                await DisplayAlert("Uwaga!", "Wybierz punkt, który chcesz usunąć.", "Ok");
            }
        }
    }
}