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
            NavigationPage.SetHasBackButton(this, true);
            FindMyLocation();
            this.recOps = new DBReceptacleOps();
            this.compOps = new DBCompanyOps();
            this.user = user;
            this.comp = compOps.GetCompany(user.CompanyID);
            
        }

        private async void AddReceptaclesClicked(object sender, EventArgs e)
        {
            // If you want your location
            //var location = await Geolocation.GetLastKnownLocationAsync();

            List<Receptacle> network = recOps.GetNetwork(user.CompanyID);             foreach (Receptacle bin in network)
            {
                //var location = bin.Location;
                var theMap = FindByName("map") as Xamarin.Forms.Maps.Map;

                try
                {
                    double lat;
                    double lon;
                    double.TryParse(bin.Latitude, out lat);
                    double.TryParse(bin.Longitude, out lon);
                    var pinLocation = new Position(lat, lon);
                    var pin = new Pin { Type = PinType.Generic, Position = pinLocation, Label = bin.Label };
                    theMap.Pins.Add(pin);
                }

                catch
                {
                    var pinLocation = new Position(bin.CompanyID, bin.ID);
                    var pin = new Pin { Type = PinType.Generic, Position = pinLocation, Label = bin.Label };
                    theMap.Pins.Add(pin);
                }
            }


                
            // recOps.AddReceptacle(user.CompanyID, "name", Position, "label");
        }

        

        private async void OnShowRoute(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            //var result = await DirectionsApi.GetRoute()
        }

        private async void FindMyLocation()
        {
            try
            {
                //var location = await Geolocation.GetLastKnownLocationAsync();

                var location = new Position(41.1408, -73.2613);

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
