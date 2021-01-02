using Acr.UserDialogs;
using MyHarvest.Base;
using MyHarvest.Services;
using MyHarvest.Services.Enum;
using MyHarvest.ViewModels;
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
        private int idUserInfo;

        private bool isEdited = false;

        public MapPage()
        {
            InitializeComponent();
            GetPermissions();
            Init();
        }

        public MapPage(int idUserInformation)
        {
            idUserInfo = idUserInformation;
            InitializeComponent();
            GetPermissions();
            Init();
            DrawRoute();
        }

        private async void DrawRoute()
        {
            locationsMap.MapElements.Clear();

            Polyline polyline = new Polyline
            {
                StrokeColor = Color.Red,
                StrokeWidth = 15
            };

            List<WaypointVm> data = new List<WaypointVm>();
            data = await WaypointService.GetWaypoints(idUserInfo);
            if (data != null)
            {
                foreach (var item in data)
                {
                    Pin newPin = new Pin()
                    {
                        Label = "punkt",
                        Type = PinType.Place
                    };

                    newPin.Position = new Xamarin.Forms.Maps.Position(item.XCoordinate, item.YCoordinate);

                    _pinList.Add(newPin);
                    locationsMap.Pins.Add(newPin);

                    newPin.MarkerClicked += (s, args) =>
                    {
                        ClickedPin(newPin);
                    };
                }
                foreach (var item in _pinList)
                {
                    polyline.Geopath.Add(item.Position);
                    locationsMap.MapElements.Add(polyline);
                }
            }
        }

        private void DrawPolyline()
        {
            locationsMap.MapElements.Clear();

            Polyline polyline = new Polyline
            {
                StrokeColor = Color.Red,
                StrokeWidth = 15
            };
            foreach (var item in _pinList)
            {
                polyline.Geopath.Add(item.Position);
                locationsMap.MapElements.Add(polyline);
            }
        }

        private void Init()
        {
            if (LocalConfig.LoginModel.IdAccountType == (int)AccountType.Employee)
            {
                EditButton.IsVisible = false;
                DeleteButton.IsVisible = false;
                SaveButton.IsVisible = false;
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
            var span = new Xamarin.Forms.Maps.MapSpan(center, 0.005, 0.005);//  1 - oznacza ile stóp w lewo i w góre ustawia się mapa od lokalizacji
            locationsMap.MoveToRegion(span);
        }

        private void LocationsMap_MapClicked(object sender, MapClickedEventArgs e)
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

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (_pinList == null)
            {
                await DisplayAlert("Błąd!", "Nie dodano żadnych punktów trasy na mapie", "Ok");
            }
            else
            {
                var pointOnTheMapListVm = new PointOnTheMapListVm();
                var list = new List<PointOnTheMapVm>();

                foreach (var item in _pinList)
                {
                    var pointOnTheMapVm = new PointOnTheMapVm();
                    pointOnTheMapVm.XCoordinate = item.Position.Latitude;
                    pointOnTheMapVm.YCoordinate = item.Position.Longitude;
                    list.Add(pointOnTheMapVm);
                }

                var data = await PointOnTheMapService.AddPointOnTheMap(list);

                var waypointListVm = new WaypointListVm();
                var ListVm = new List<WaypointVm>();
                foreach (var item in data)
                {
                    var waypointVm = new WaypointVm();
                    waypointVm.IdPointOnTheMap = item.IdPointOnTheMap;
                    waypointVm.IdUserInformation = idUserInfo;
                    ListVm.Add(waypointVm);
                }

                WaypointService.AddWaypoint(ListVm);
                await DisplayAlert("Informacja!", "Zapisano nową trasę.", "Ok");
            }
        }
    }
}