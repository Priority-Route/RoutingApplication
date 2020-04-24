using System;
using PriorityRoute.Data;
using PriorityRoute.Models;
using SQLite;
using Xamarin.Forms;

namespace PriorityRoute.Views
{
    public class ReceptacleView : ContentPage
    {
        private ListView _listView;

        public ReceptacleView()
        {
            this.Title = "Receptacles";

            SQLiteConnection conn = DependencyService.Get<ISQLite>().GetConnection();

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = conn.Table<Receptacle>().OrderBy(x => x.Name).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;
            
        }
    }
}

