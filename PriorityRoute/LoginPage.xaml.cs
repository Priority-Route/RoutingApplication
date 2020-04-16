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
            //String username = (string)Usernameview;
            var Passwordview = FindByName("Entr_Password") as Entry;

            DBOps dbops = new DBOps();

            //User user = dbops.VerifyUsernameAsync(Usernameview.Text);
            bool login = await dbops.VerifyUsernameAsync(Usernameview.ToString(), Passwordview.ToString());
            User user = await dbops.GetUserAsync(1);
            if (login)
            {
                await Navigation.PushAsync(new MainPage(user));               
            }
            else
            {
                await DisplayAlert("Invalid User.", "This user does not exist", "Cancel");
            }

            
        }
    }
}
