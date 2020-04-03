using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PriorityRoute
{
    public partial class RoutingScreen : ContentPage
    {
        public RoutingScreen()
        {
            InitializeComponent();
        }
        private async void RoutingScreenClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
