using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Linq;
using PriorityRoute.Models;

namespace PriorityRoute.Data
{
    public class DBPinOps
    {
        SQLiteConnection conn;

        public DBPinOps()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<PriorityRoute.Models.Pin>();
        }

        public Boolean AddPin(PriorityRoute.Models.Pin pin)
        {
            if (GetPin(pin.ID) == null)
            {
                conn.Insert(pin);
                return true;
            }
            return false;
        }

        public Boolean AddPin(String name, double lat, double lon, String label)
        {
            String latToAdd = lat.ToString();
            String lonToAdd = lon.ToString();

            PriorityRoute.Models.Pin pinToAdd = new PriorityRoute.Models.Pin();
            pinToAdd.Name = name;
            pinToAdd.Latitude = latToAdd;
            pinToAdd.Longitude = lonToAdd;
            pinToAdd.Label = label;

            if (GetPin(name) != null)
            {
                AddPin(pinToAdd);
                return true;
            }
            return false;
        }

        public Boolean AddPin(String name, Position location, String label)
        {
            double latToAdd = location.Latitude;
            double lonToAdd = location.Longitude;

            return AddPin(name, latToAdd, lonToAdd, label);
        }
      
        public PriorityRoute.Models.Pin GetPin(int id)
        {
            return conn.Table<PriorityRoute.Models.Pin>().Where(x => x.ID == id).FirstOrDefault();
        }

        public PriorityRoute.Models.Pin GetPin(String name)
        {
            return conn.Table<PriorityRoute.Models.Pin>().Where(x => x.Name.Equals(name)).FirstOrDefault();
        }

        public List<PriorityRoute.Models.Pin> GetNetwork(int compID)
        {
            return conn.Table<PriorityRoute.Models.Pin>().Where(x => x.CompanyID == compID).ToList();
        }

        public int UpdatePin(PriorityRoute.Models.Pin pin)
        {
            if (GetPin(pin.ID) != null)
            {
                conn.Update(pin);
                return pin.ID;
            }
            AddPin(pin);
            return pin.ID;
        }

        public int DeletePin(PriorityRoute.Models.Pin pin)
        {
            return conn.Delete<PriorityRoute.Models.Pin>(pin.ID);
        }
    }
}
