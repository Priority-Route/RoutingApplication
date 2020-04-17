using System;
using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace PriorityRoute.Data
{
    public class DBCompanyOps
    {
        SQLiteConnection conn;

        public DBCompanyOps()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Company>();
            
            Company admin = new Company();
            admin.Name = "Priority Route";
            this.AddCompany(admin);
        }

        public Boolean AddCompany(Company comp)
        {
            if (GetCompany(comp.Name) == null)
            {
                conn.Insert(comp);
                return true;
            }
            return false;
        }

        public Company GetCompany(int id)
        {
            return conn.Table<Company>().Where(x => x.ID == id).FirstOrDefault();
        }

        public Company GetCompany(String name)
        {
            return conn.Table<Company>().Where(x => x.Name == name).FirstOrDefault();
        }

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

        public int DeleteCompany(Company comp)
        {
            return conn.Delete<Company>(comp.ID);
        }
    }
}