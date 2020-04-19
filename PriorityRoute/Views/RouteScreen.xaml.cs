// File name: RouteScreen.xaml.cs
// Purpose: Supporting C# code for RouteScreen.xaml
// 
// @author Philip Ruggirello

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
        // logged in user information
        User user;
        // user's company
        Company comp;

        // object to access Receptacle database
        DBReceptacleOps recOps;
        // object to access Company database
        DBCompanyOps compOps;

        // object of all receptacles in one company
        List<Receptacle> network;
        // object with lines for directions
        readonly List<Polyline> plottedRoutes = new List<Polyline>();
        // array of colors for PolyLine object
        readonly Color[] color = { Color.Red, Color.Blue, Color.Green, Color.Yellow };

        // opens page with valid user information
        public RouteScreen(User user)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);
            FindMyLocation();
            this.recOps = new DBReceptacleOps();
            this.compOps = new DBCompanyOps();
            this.user = user;
            // gets user's company
            this.comp = compOps.GetCompany(user.CompanyID);
            
        }

        // adds receptacles to map view
        private async void AddReceptaclesClicked(object sender, EventArgs e)
        {
            // If you want your location
            //var location = await Geolocation.GetLastKnownLocationAsync();

            // setting the network object with the user's company information
            network = recOps.GetNetwork(user.CompanyID); 
            
            // for every receptacle in the network
            foreach (Receptacle bin in network)
            {
                //var location = bin.Location;
                var theMap = FindByName("map") as Xamarin.Forms.Maps.Map;

                // fill the pin with information from the receptacle database
                try
                {
                    // get latitude and longitude
                    double lat;
                    double lon;
                    // convert from string to double
                    double.TryParse(bin.Latitude, out lat);
                    double.TryParse(bin.Longitude, out lon);
                    var pinLocation = new Position(lat, lon);
                    // place pin on map view
                    var pin = new Pin { Type = PinType.Generic, Position = pinLocation, Label = bin.Label };
                    theMap.Pins.Add(pin);
                    await DisplayAlert("Receptacles Added", "The Receptacles Have Been Added to the Map.", "OK");
                }
                // in case the conversion from String to double is unsuccessful
                catch
                {
                    var pinLocation = new Position(bin.CompanyID, bin.ID);
                    var pin = new Pin { Type = PinType.Generic, Position = pinLocation, Label = bin.Label };
                    theMap.Pins.Add(pin);
                    await DisplayAlert("Receptacles Added", "The Receptacles Have Been Added to the Map.", "OK");
                }
            }


                
            // recOps.AddReceptacle(user.CompanyID, "name", Position, "label");
        }

        

        private async void OnShowRoute(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            //var result = await DirectionsApi.GetRoute()
        }
        private async void LogOutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInPage());
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
