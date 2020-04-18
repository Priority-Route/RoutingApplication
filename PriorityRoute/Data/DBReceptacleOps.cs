using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Linq;
using PriorityRoute.Models;

namespace PriorityRoute.Data
{
    public class DBReceptacleOps
    {
        SQLiteConnection conn;

        public DBReceptacleOps()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Receptacle>();
        }

        public Boolean AddReceptacle(Receptacle pin)
        {
            if (GetReceptacle(pin.ID) == null)
            {
                conn.Insert(pin);
                return true;
            }
            return false;
        }

        public Boolean AddReceptacle(int compID, String name, double lat, double lon, String label)
        {
            String latToAdd = lat.ToString();
            String lonToAdd = lon.ToString();

            Receptacle pinToAdd = new Receptacle();
            pinToAdd.CompanyID = compID;
            pinToAdd.Name = name;
            pinToAdd.Latitude = latToAdd;
            pinToAdd.Longitude = lonToAdd;
            pinToAdd.Label = label;

            if (GetReceptacle(name) != null)
            {
                AddReceptacle(pinToAdd);
                return true;
            }
            return false;
        }

        public Boolean AddReceptacle(int compID, String name, Position location, String label)
        {
            double latToAdd = location.Latitude;
            double lonToAdd = location.Longitude;

            return AddReceptacle(compID, name, latToAdd, lonToAdd, label);
        }
      
        public Receptacle GetReceptacle(int id)
        {
            return conn.Table<Receptacle>().Where(x => x.ID == id).FirstOrDefault();
        }

        public Receptacle GetReceptacle(String name)
        {
            return conn.Table<Receptacle>().Where(x => x.Name.Equals(name)).FirstOrDefault();
        }

        public List<Receptacle> GetNetwork(int compID)
        {
            return conn.Table<Receptacle>().Where(x => x.CompanyID == compID).ToList();
        }

        public int UpdatePin(Receptacle rec)
        {
            if (GetReceptacle(rec.ID) != null)
            {
                conn.Update(rec);
                return rec.ID;
            }
            AddReceptacle(rec);
            return rec.ID;
        }

        public int DeletePin(Receptacle rec)
        {
            return conn.Delete<Receptacle>(rec.ID);
        }
    }
}
