// File name: ManageUsers.xaml.cs
// Purpose: Supporting C# code for ManageUsers.xaml
// 
// @author Phillip Ruggirello

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
        // logged in user information
        User user;
        User userToAdd = new User();

        // object to access User database
        DBUserOps userOps = new DBUserOps();

        // opens page with valid user information
        public ManageUsers(User user)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            this.user = user;
        }

        // adds user to database
        private async void AddUserClicked(object sender, EventArgs e)
        {
            // if any of the fields are invalid
            if ((string.IsNullOrWhiteSpace(userNameEntry.Text)) ||
                (string.IsNullOrWhiteSpace(passwordEntry.Text)) ||
                (string.IsNullOrEmpty(userNameEntry.Text)) ||
                (string.IsNullOrEmpty(passwordEntry.Text)))

            {
<<<<<<< Updated upstream
                // display error message
                await DisplayAlert("Enter Data", "Enter Valid Data", "OK");
=======
                await DisplayAlert("Invalid Entry", "Please Make Sure That the Data You Have Entered is Correct.", "OK");
>>>>>>> Stashed changes
            }
            // if all of the fields are valid
            else
            {
                // insert information from fields to user object
                userToAdd.Username = userNameEntry.Text;
                userToAdd.Password = passwordEntry.Text;
                
                // by default users should not be administrators
                userToAdd.Administrator = 0;

                try
                {
                    // add user to database
                    var returnvalue = userOps.AddUser(userToAdd);

                    // if user is successfully added
                    if (returnvalue)
                    {
                        // display success message
                        await DisplayAlert("User Add", "User Successfully Added to Database", "OK");
                        // go back to login page
                        await Navigation.PushAsync(new LogInPage());
                    }
                    // if user is not successfully added
                    else
                    {
                        // display error message
                        await DisplayAlert("User Add", "Please Try Again", "OK");

                        // reset input fields
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

        // return to home screen
        private async void HomeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void LogOutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInPage());
        }
    }
}

