using System;
using SQLite;
using Xamarin.Forms;
using System.Linq;
using PriorityRoute.Models;

namespace PriorityRoute.Data
{
    public class DBCompanyOps
    {
        // opening connection to database
        SQLiteConnection conn;

        // initiating constructor
        // creating necessary objects
        public DBCompanyOps()
        {
            // setting connection to database file
            // creating applicable table
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Company>();
            
            // instantiating default (admin) user/company information
            Company admin = new Company();
            admin.Name = "Priority Route";
            this.UpdateCompany(admin);
        }

        // adds company to database
        // requires company object
        // returns boolean
        public Boolean AddCompany(Company comp)
        {
            if (GetCompany(comp.Name) == null)
            {
                conn.Insert(comp);
                return true;
            }
            return false;
        }

        // gets company from database
        // requires company ID
        // returns company object
        public Company GetCompany(int id)
        {
            return conn.Table<Company>().Where(x => x.ID == id).FirstOrDefault();
        }

        // gets company from database
        // requires company name
        // returns company object
        public Company GetCompany(String name)
        {
            return conn.Table<Company>().Where(x => x.Name == name).FirstOrDefault();
        }

        // updates company information in database
        // requires company object
        // returns int company ID
        public int UpdateCompany(Company comp)
        {
            if (GetCompany(comp.ID) != null)
            {
                conn.Update(comp);
                return comp.ID;
            }
            AddCompany(comp);
            return comp.ID;
        }

        // deletes company from database
        // requires company object
        // returns company ID
        public int DeleteCompany(Company comp)
        {
            return conn.Delete<Company>(comp.ID);
        }
    }
}