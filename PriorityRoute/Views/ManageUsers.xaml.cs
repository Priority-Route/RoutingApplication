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
        User user;
        User userToAdd = new User();
        DBUserOps userOps = new DBUserOps();

        public ManageUsers(User user)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            this.user = user;
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

                userToAdd.Username = userNameEntry.Text;
                userToAdd.Password = passwordEntry.Text;
                userToAdd.Administrator = 0;

                try
                {
                    var returnvalue = userOps.AddUser(userToAdd);
                    if (returnvalue)
                    {
                        await DisplayAlert("User Add", "User Successfully Added to Database", "OK");
                        await Navigation.PushAsync(new LogInPage());
                    }
                    else
                    {
                        await DisplayAlert("User Add", "Please Try Again", "OK");


                        userNameEntry.Text = string.Empty;
                        passwordEntry.Text = string.Empty;

                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                Navigation.PushAsync(new LogInPage());

            }

        }
        private async void HomeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(this.user));
        }
    }
}

