using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using System.Linq;
using PriorityRoute.Models;

namespace PriorityRoute.Data
{
    public class DBBinOps
    {
        SQLiteConnection conn;

        public DBBinOps()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Bin>();
        }

        public Boolean AddPoint(Bin bin)
        {
            if (GetPoint(bin.ID) == null)
            {
                conn.Insert(bin);
                return true;
            }
            return false;
        }
      
        public Bin GetPoint(int id)
        {
            return conn.Table<Bin>().Where(x => x.ID == id).FirstOrDefault();
        }

        public List<Bin> GetNetwork(int compID)
        {
            return conn.Table<Bin>().Where(x => x.CompanyID == compID).ToList();
        }

        public int UpdatePoint(Bin bin)
        {
            if (GetPoint(bin.ID) != null)
            {
                conn.Update(bin);
                return bin.ID;
            }
            AddPoint(bin);
            return bin.ID;
        }

        public int DeletePoint(Bin bin)
        {
            return conn.Delete<Bin>(bin.ID);
        }
    }
}
