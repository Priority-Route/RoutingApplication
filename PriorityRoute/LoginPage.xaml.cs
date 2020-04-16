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
        private void LoginClicked(object sender, EventArgs e)
        {
            var Usernameview = FindByName("Entr_Username") as Entry;
            //String username = (string)Usernameview;
            var Passwordview = FindByName("Entr_Password") as Entry;

            DBOps dbops = new DBOps();

            //User user = dbops.VerifyUsernameAsync(Usernameview.Text);
            Boolean login = dbops.VerifyUsernameAsync(Usernameview.ToString(), Passwordview.ToString());
            if (login)
            {
                Navigation.PushAsync(new MainPage(user));               
            }
            else
            {
                DisplayAlert("Invalid User.", "This user does not exist", "Cancel");
            }

            
        }
    }
}
