using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace PriorityRoute.Data
{
    public class DBUserOps
    {
        SQLiteConnection conn;

        public DBUserOps()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<User>();

            User admin = new User();
            admin.Username = "admin";
            admin.Password = "PRadmin01";
            this.AddUser(admin);
        }

        public Boolean AddUser(User user)
        {
            if (GetUser(user.Username) == null)
            {
                conn.Insert(user);
                return true;
            }
            return false;
        }

        public Boolean VerifyUser(String username, String password)
        {
            User toVerify = GetUser(username);
            if (toVerify != null)
            {
                if (toVerify.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public User GetUser(int id)
        {
            return conn.Table<User>().Where(x => x.ID == id).FirstOrDefault();
        }

        public User GetUser(String username)
        {
            return conn.Table<User>().Where(x => x.Username == username).FirstOrDefault();
        }

        public List<User> GetEmployees(int compID)
        {
            return conn.Table<User>().Where(x => x.CompanyID == compID).ToList();
        }

        public int UpdateUser(User user)
        {
            if (GetUser(user.ID) != null)
            {
                conn.Update(user);
                return user.ID;
            }
            AddUser(user);
            return user.ID;
        }

        public int DeleteUser(User user)
        {
            return conn.Delete<User>(user.ID);
        }
    }
}