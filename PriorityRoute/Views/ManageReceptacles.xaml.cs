// File name: ManageReceptacles.xaml.cs
// Purpose: Supporting C# code for ManageReceptacles.xaml
// 
// @author Philip Ruggirello

using System;
using System.Collections.Generic;
using PriorityRoute.Data;
using PriorityRoute.Models;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace PriorityRoute.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageReceptacles : ContentPage
    {
        // logged in user information
        User user;
        Receptacle receptacle;
        Receptacle receptacleToAdd = new Receptacle();

        // object to access Receptacle database
        DBReceptacleOps receptacleOps= new DBReceptacleOps();

        // opens page with valid user information
        public ManageReceptacles(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private async void LogOutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInPage());
        }

        private async void RemoveReceptaclesClicked(object sender, EventArgs e)
        {
            // gets all receptacles given the user's company
            List<Receptacle> network = receptacleOps.GetNetwork(user.CompanyID);
            
            // for every receptacle in the network
            foreach (Receptacle bin in network)
            {
                // delete the receptacle
                receptacleOps.DeleteReceptacle(bin);
                await DisplayAlert("Receptacles Deleted", "You Have Removed All Receptacles From the Map.", "OK");
            }
        }

        // adds receptacle to the map view
        private async void AddReceptacleClicked(object sender, EventArgs e)
        {
            // if any field is invalid
            if ((string.IsNullOrWhiteSpace(nameEntry.Text)) || (string.IsNullOrEmpty(nameEntry.Text)) ||
                (string.IsNullOrWhiteSpace(latitudeEntry.Text)) || (string.IsNullOrEmpty(latitudeEntry.Text)) ||
                (string.IsNullOrWhiteSpace(longitudeEntry.Text)) || (string.IsNullOrEmpty(longitudeEntry.Text)) ||
                (string.IsNullOrWhiteSpace(infoEntry.Text)) || (string.IsNullOrEmpty(infoEntry.Text)))
            {

                // try inputting data again
                await DisplayAlert("Invalid Receptacle Data", "Please Make Sure the Data You Are Entering is Correct", "OK");

            }
            // if all fields are valid
            else
            {
                // set information in tentative receptacle with inputted data
                receptacleToAdd.Name = nameEntry.Text;
                receptacleToAdd.Latitude = latitudeEntry.Text;
                receptacleToAdd.Longitude = longitudeEntry.Text;
                receptacleToAdd.Label = infoEntry.Text;
                
                // set company to Priority Route for now (REMOVE AT DEPLOYMENT)
                receptacleToAdd.CompanyID = 1;

                try
                {
                    // add receptacle with information to database
                    var returnvalue = receptacleOps.AddReceptacle(receptacleToAdd);

                    // if addition is successful
                    if (returnvalue)
                    {

                        // display success message
                        await DisplayAlert("Receptacle Added", "The Receptacle You Added Has Been Added to the Map", "OK");


                        // reset data entry fields
                        nameEntry.Text = string.Empty;
                        latitudeEntry.Text = string.Empty;
                        longitudeEntry.Text = string.Empty;
                        infoEntry.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                Navigation.PopAsync();
            }
        }

    }
}
