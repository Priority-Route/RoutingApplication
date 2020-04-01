using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PriorityRoute
{
    public partial class ManageUsers : ContentPage
    {
        public ManageUsers()
        {
            InitializeComponent();
        }
        private async void ManageUsersClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
