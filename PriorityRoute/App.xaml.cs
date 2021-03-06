﻿using System;
using Xamarin.Forms;
using PriorityRoute.Data;
using PriorityRoute.Views;
using Xamarin.Forms.Xaml;

namespace PriorityRoute
{
    public partial class App : Application
    {
        static DBUserOps userDatabase;
        static DBCompanyOps companyDatabase;
        static DBReceptacleOps receptacleDatabase;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LogInPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static DBUserOps UserDatabase
        {
            get
            {
                if(userDatabase == null)
                {
                    userDatabase = new DBUserOps();
                }
                return userDatabase;
            }
        }

        public static DBCompanyOps CompanyDatabase
        {
            get
            {
                if(companyDatabase == null)
                {
                    companyDatabase = new DBCompanyOps();
                }
                return companyDatabase;
            }
        }

        public static DBReceptacleOps ReceptacleDatabase
        {
            get
            {
                if(receptacleDatabase == null)
                {
                    receptacleDatabase = new DBReceptacleOps();
                }
                return receptacleDatabase;
            }
        }
    }
}
