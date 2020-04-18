using System;
using System.Collections.Generic;
using PriorityRoute.Data;
using PriorityRoute.Models;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriorityRoute.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageReceptacles : ContentPage
    {
        Receptacle receptacle;
        Receptacle receptacleToAdd = new Receptacle();
        DBReceptacleOps receptacleOps= new DBReceptacleOps();

        public ManageReceptacles()
        {
            InitializeComponent();
        }

        private async void AddReceptacleClicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(nameEntry.Text)) || (string.IsNullOrEmpty(nameEntry.Text)) ||
                (string.IsNullOrWhiteSpace(latitudeEntry.Text)) || (string.IsNullOrEmpty(latitudeEntry.Text)) ||
                (string.IsNullOrWhiteSpace(longitudeEntry.Text)) || (string.IsNullOrEmpty(longitudeEntry.Text)) ||
                (string.IsNullOrWhiteSpace(infoEntry.Text)) || (string.IsNullOrEmpty(infoEntry.Text)))
            {
                await DisplayAlert("Enter Data", "Enter Valid Data", "OK");
            }
            else
            {
                receptacleToAdd.Name = nameEntry.Text;
                receptacleToAdd.Latitude = latitudeEntry.Text;
                receptacleToAdd.Longitude = longitudeEntry.Text;
                receptacleToAdd.Label = infoEntry.Text;

                try
                {
                    var returnvalue = receptacleOps.AddReceptacle(receptacleToAdd);
                    if (returnvalue)
                    {
                        await DisplayAlert("Receptacle to Add", "Please Try Again", "OK");

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
