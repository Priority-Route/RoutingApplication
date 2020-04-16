using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PriorityRoute
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        
        private async void LoginClicked(object sender, EventArgs e)
        {
            var Usernameview = FindByName("Entr_Username") as Entry;
            String username = Usernameview.ToString();
            var Passwordview = FindByName("Entr_Password") as Entry;
            String password = Passwordview.ToString();

            DBOps dbops = new DBOps();

            bool login = await dbops.VerifyUsernameAsync(username, password);
            if (login)
            {
                User user = dbops.GetUserAsync(username);
                await Navigation.PushAsync(new MainPage(user));
            }
            else
            {
                await DisplayAlert("Invalid User.", "This user does not exist", "Cancel");
            }

            
        }
    }
}
