// File name: MainPage.xaml.cs
// Purpose: Supporting C# code for MainPage.xaml
// 
// @author Philip Ruggirello

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriorityRoute.Models;
using PriorityRoute.Views;
using Xamarin.Forms;

namespace PriorityRoute.Views
{
    // https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        // logged in user information
        User user;

        // opens page with valid user information
        public MainPage(User user)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            this.user = user;
        }

        // opens Manage Users page with valid user information
        private async void ManageDriversClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManageUsers(this.user));
        }

        // opens Route Screen page with valid user information
        private async void FindMyRouteClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RouteScreen(this.user));
        }

        // opens Manage Receptacles page with valid user information
        private async void ManageReceptaclesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManageReceptacles(this.user));
        }
        private async void LogOutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInPage());
        }
    }
}
