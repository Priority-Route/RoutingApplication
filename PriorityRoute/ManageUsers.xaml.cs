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
        private void AddUserClicked(object sender, EventArgs e)
        {
            var Usernameview = FindByName("Entr_Username") as Entry;
            var Passwordview = FindByName("Entr_Password") as Entry;

            // User user = new User(Usernameview.Text, Passwordview.Text)

            DBOps dbops = new DBOps();
            if (dbops.VerifyUser(Usernameview.Text, Passwordview.Text))
            {
                DisplayAlert("Duplicate User.", "The user you tried to create is already in the system.", "Cancel" );
            }
            else
            {
                dbops.AddUser(Usernameview.Text, Passwordview.Text);
            }
            
        }
        private async void HomeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
