﻿using System;
using PriorityRoute.Data;
using PriorityRoute.Models;
using PriorityRoute.TestFiles;
using SQLite;
using Xamarin.Forms;

namespace PriorityRoute.Views
{
    public class UserView : ContentPage
    {
        private ListView _listView;

        public UserView()
        {
            this.Title = "Users";

            SQLiteConnection conn = DependencyService.Get<ISQLite>().GetConnection();

            DBInsertObjects dbio = new DBInsertObjects();
            DBInsertData dbid = new DBInsertData();

            dbio.RunTest();
            dbid.RunTest();

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = conn.Table<User>().OrderBy(x => x.Username).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }
    }
}

