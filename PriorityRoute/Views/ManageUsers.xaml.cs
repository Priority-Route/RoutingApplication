using System;
using System.Collections.Generic;
using PriorityRoute.Data;
using System.Diagnostics;
using PriorityRoute.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriorityRoute.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageUsers : ContentPage
    {
        User users = new User();
        UserDatabaseController userDB = new UserDatabaseController();
        public ManageUsers()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
        }
        private async void AddUserClicked(object sender, EventArgs e)
        {

            if ((string.IsNullOrWhiteSpace(userNameEntry.Text)) ||
                (string.IsNullOrWhiteSpace(passwordEntry.Text)) ||
                (string.IsNullOrEmpty(userNameEntry.Text)) ||
                (string.IsNullOrEmpty(passwordEntry.Text)))

            {
                await DisplayAlert("Enter Data", "Enter Valid Data", "OK");
            }




            else
            {

                users.userName = userNameEntry.Text;
                users.password = passwordEntry.Text;

                try
                {
                    var retrunvalue = userDB.AddUser(users);
                    if (retrunvalue == "Sucessfully Added")
                    {
                        await DisplayAlert("User Add", retrunvalue, "OK");
                        await Navigation.PushAsync(new LoginPage());
                    }
                    else
                    {
                        await DisplayAlert("User Add", retrunvalue, "OK");


                        userNameEntry.Text = string.Empty;
                        passwordEntry.Text = string.Empty;

                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                Navigation.PushAsync(new LoginPage());

            }

        }
        private async void HomeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}

