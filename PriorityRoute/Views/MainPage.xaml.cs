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
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ManageDriversClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManageUsers());
        }

        private async void FindMyRouteClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RouteScreen());
        }
    }
}
