using System;
using System.Data.SQLite;

namespace Version
{
    class DBVerCheck
    {
        public void Main(String[] args)
        {
            string cs = "Data Source=PriorityRoute/PRDB01";
            string stm = "SELECT SQLITE_VERSION()";

            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(stm, con);
            string version = cmd.ExecuteScalar().ToString();

            Console.WriteLine($"SQLite version: {version}");
        }
    }
}