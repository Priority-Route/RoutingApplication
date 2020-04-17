using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace PriorityRoute.Data
{
    public class DBPointOps
    {
        SQLiteConnection conn;

        public DBPointOps()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Point>();
        }

        public Boolean AddPoint(Point point)
        {
            if (GetPoint(point.Designation) == null)
            {
                conn.Insert(point);
                return true;
            }
            return false;
        }
      
        public Point GetPoint(int id)
        {
            return conn.Table<Point>().Where(x => x.Designation == id).FirstOrDefault();
        }

        public List<Point> GetNetwork(int compID)
        {
            return conn.Table<Point>().Where(x => x.CompanyID == compID).ToList();
        }

        public int UpdatePoint(Point point)
        {
            if (GetPoint(point.Designation) != null)
            {
                conn.Update(point);
                return point.Designation;
            }
            AddPoint(point);
            return point.Designation;
        }

        public int DeletePoint(Point point)
        {
            return conn.Delete<Point>(point.Designation);
        }
    }
}
