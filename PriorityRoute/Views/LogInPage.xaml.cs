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
        DBUserOps userOps = new DBUserOps();
        public LogInPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
        }

        public async void LoginClicked(object sender, EventArgs e)
        {
            if(userNameEntry.Text != null && passwordEntry.Text != null)
            {

                var validData = userOps.VerifyUser(userNameEntry.Text, passwordEntry.Text);
                if (validData)
                {
                    User user  = userOps.GetUser(userNameEntry.Text);
                    await Navigation.PushAsync(new MainPage(user));
                }
                else
                {
                    await DisplayAlert("Login Failed", "Username or Password Incorrect", "OK");
                }
            }
        }
    }
}
