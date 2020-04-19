// File name: LoginPage.xaml.cs
// Purpose: Supporting C# code for LoginPage.xaml
// 
// @author Philip Ruggirello

using System;
using System.Collections.Generic;
using PriorityRoute.Data;
using PriorityRoute.Models;
using PriorityRoute.Views;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace PriorityRoute.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        // creating object to access user database
        DBUserOps userOps = new DBUserOps();

        public LogInPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
        }

        // verifies user credentials and grants access to app
        public async void LoginClicked(object sender, EventArgs e)
        {
            // if username and pasword are not null values
            if (userNameEntry.Text != null && passwordEntry.Text != null)
            {
                // uses user database to verify user credentials
                var validData = userOps.VerifyUser(userNameEntry.Text, passwordEntry.Text);
                
                // if user is valid
                if (validData)
                {
                    // get user from database
                    User user  = userOps.GetUser(userNameEntry.Text);
                    // grant access to main page and pass user information
                    await Navigation.PushAsync(new MainPage(user));
                }
                // if user is not valid
                else
                {
                    // display error message
                    await DisplayAlert("Login Failed", "Username or Password Incorrect", "OK");
                }
            }
        }
    }
}
