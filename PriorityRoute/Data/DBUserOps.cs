using System;
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