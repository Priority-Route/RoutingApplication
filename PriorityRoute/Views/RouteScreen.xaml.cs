using System;
using System.Collections.Generic;
using PriorityRoute.Models;
using PriorityRoute.Data;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PriorityRoute.Views
{


    public partial class RouteScreen : ContentPage
    {
        User user;
        Company comp;
        DBReceptacleOps recOps;
        DBCompanyOps compOps;

        List<Receptacle> network;
        readonly List<Polyline> plottedRoutes = new List<Polyline>();
        readonly Color[] color = { Color.Red, Color.Blue, Color.Green, Color.Yellow };

        public RouteScreen(User user)
        {
            InitializeComponent();
            FindMyLocation();
            this.recOps = new DBReceptacleOps();
            this.compOps = new DBCompanyOps();
            this.user = user;
            this.comp = compOps.GetCompany(user.CompanyID);
            this.network = this.comp.Network; 
        }

        private async void AddReceptaclesClicked(object sender, EventArgs e)
        {
            // If you want your location
            //var location = await Geolocation.GetLastKnownLocationAsync();

            var location = new Position(41.1588, 73.2574);
            var theMap = FindByName("map") as Xamarin.Forms.Maps.Map;
            var mapCenter = new Position(location.Latitude, location.Longitude);
            var pin = new Pin { Type = PinType.Generic, Position = mapCenter, Label = "MyCar" };
            theMap.Pins.Add(pin);

            // recOps.AddReceptacle(user.CompanyID, "name", Position, "label");
        }

        private async void OnShowRoute(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            var result = await DirectionsApi.GetRoute()
        }

        private async void FindMyLocation()
        {
            try
            {
                //var location = await Geolocation.GetLastKnownLocationAsync();

                var location = new Position(41.1408, 73.2613);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");

                    var theMap = FindByName("map") as Xamarin.Forms.Maps.Map;
                    var mapCenter = new Position(location.Latitude, location.Longitude);

                    theMap.MoveToRegion(MapSpan.FromCenterAndRadius(mapCenter, Distance.FromMiles(1)));

                    theMap.MapClicked += OnShowRoute;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle no supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}
