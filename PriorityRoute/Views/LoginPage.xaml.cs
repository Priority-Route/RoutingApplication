using System;
using PriorityRoute.Data;
//using PriorityRoute.Models;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace PriorityRoute.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        UserDatabaseController userDB = new UserDatabaseController();
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
        }

        public async void LoginClicked(object sender, EventArgs e)
        {
            if (userNameEntry.Text != null && passwordEntry.Text != null)
            {
                var validData = userDB.LoginValidate(userNameEntry.Text, passwordEntry.Text);
                if (validData)
                {

                    await Navigation.PushAsync(new MainPage());
                    Navigation.RemovePage(this);

                }
                else
                {

                    await DisplayAlert("Login Failed", "Username or Password Incorrect", "OK");
                }

            }

        }
    }
}

