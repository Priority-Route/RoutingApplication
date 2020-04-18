using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
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
            conn.CreateTable<Pin>();
        }

        public Boolean AddPin(Pin pin)
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

            Pin pinToAdd = new Pin();
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
      
        public Pin GetPin(int id)
        {
            return conn.Table<Pin>().Where(x => x.ID == id).FirstOrDefault();
        }

        public Pin GetPin(String name)
        {
            return conn.Table<Pin>().Where(x => x.Name.Equals(name)).FirstOrDefault();
        }

        public List<Pin> GetNetwork(int compID)
        {
            return conn.Table<Pin>().Where(x => x.CompanyID == compID).ToList();
        }

        public int UpdatePin(Pin pin)
        {
            if (GetPin(pin.ID) != null)
            {
                conn.Update(pin);
                return pin.ID;
            }
            AddPin(pin);
            return pin.ID;
        }

        public int DeletePin(Pin pin)
        {
            return conn.Delete<Pin>(pin.ID);
        }
    }
}
