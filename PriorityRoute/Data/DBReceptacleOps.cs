// File name: DBReceptacleOps.cs
// Purpose: provide users with access to the database Receptacle table and methods to manipulate Receptacle objects
// 
// @author Christian Hakim

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
        // opening connection to database
        SQLiteConnection conn;

        // initiating constructor
        // creating necessary objects
        public DBReceptacleOps()
        {
            // setting connection to database file
            // creating applicable table
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Receptacle>();
        }

        // add receptacle to database
        // requires receptacle object
        // returns boolean
        public Boolean AddReceptacle(Receptacle pin)
        {
            if (GetReceptacle(pin.ID) == null)
            {
                conn.Insert(pin);
                return true;
            }
            return false;
        }

        // add receptacle to database
        // requires company ID, receptacle name, receptacle latitude, receptacle longitude, receptacle label
        // returns boolean
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

        // add receptacle to database
        // requires company ID, receptacle name, receptacle Position, receptacle label
        // returns boolean
        public Boolean AddReceptacle(int compID, String name, Position location, String label)
        {
            double latToAdd = location.Latitude;
            double lonToAdd = location.Longitude;

            return AddReceptacle(compID, name, latToAdd, lonToAdd, label);
        }
      
        // get receptacle from database
        // requires receptacle ID
        // returns receptacle object
        public Receptacle GetReceptacle(int id)
        {
            return conn.Table<Receptacle>().Where(x => x.ID == id).FirstOrDefault();
        }

        // get receptacle from database
        // requires receptacle name
        // returns receptacle object
        public Receptacle GetReceptacle(String name)
        {
            return conn.Table<Receptacle>().Where(x => x.Name.Equals(name)).FirstOrDefault();
        }

        // gets all receptacles from database in a company
        // requires company ID
        // returns List of receptacle objects
        public List<Receptacle> GetNetwork(int compID)
        {
            return conn.Table<Receptacle>().Where(x => x.CompanyID == compID).ToList();
        }

        // udpates receptacle in database
        // requires receptacle object
        // returns receptacle ID
        public int UpdateReceptacle(Receptacle rec)
        {
            if (GetReceptacle(rec.ID) != null)
            {
                conn.Update(rec);
                return rec.ID;
            }
            AddReceptacle(rec);
            return rec.ID;
        }

        // deletes receptacle in database
        // requires receptacle object
        // returns receptacle ID
        public int DeleteReceptacle(Receptacle rec)
        {
            return conn.Delete<Receptacle>(rec.ID);
        }
    }
}
