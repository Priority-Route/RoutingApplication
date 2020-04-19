// File name: DBUserOps.cs
// Purpose: provide users with access to the database User table and methods to manipulate User objects
// 
// @author Christian Hakim

using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using System.Linq;
using PriorityRoute.Models;

namespace PriorityRoute.Data
{
    public class DBUserOps
    {
        // opening connection to database
        SQLiteConnection conn;


        // initiating constructor
        // creating necessary objects
        public DBUserOps()
        {
            // setting connection to database file
            // creating applicable table
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<User>();

            // instantiating default (admin) user/company information
            User admin = new User();
            admin.Username = "admin";
            admin.Password = "PRadmin01";
            admin.Administrator = 1;
            admin.CompanyID = 1;
            this.UpdateUser(admin);
        }

        // adds user to database
        // requires user object
        // returns boolean
        public Boolean AddUser(User user)
        {
            if (GetUser(user.Username) == null)
            {
                conn.Insert(user);
                return true;
            }
            return false;
        }

        // verifies user login credentials
        // requires user username, user password
        // returns boolean
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

        // gets user from database
        // requires user ID
        // returns user object
        public User GetUser(int id)
        {
            return conn.Table<User>().Where(x => x.ID == id).FirstOrDefault();
        }

        // gets user from database
        // requires user username
        // returns user object
        public User GetUser(String username)
        {
            return conn.Table<User>().Where(x => x.Username == username).FirstOrDefault();
        }

        // gets users from database for certain company
        // requires company ID
        // returns List of user objects
        public List<User> GetEmployees(int compID)
        {
            return conn.Table<User>().Where(x => x.CompanyID == compID).ToList();
        }

        // updates user information in database
        // requires user object
        // returns user ID
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

        // deletes user from database
        // requires user object
        // returns user ID
        public int DeleteUser(User user)
        {
            return conn.Delete<User>(user.ID);
        }
    }
}