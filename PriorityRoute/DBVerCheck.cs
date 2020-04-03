using System;
using System.Data.SQLite;

namespace Version
{
    class DBVerCheck
    {
        static void Main(String[] args)
        {
            string cs = "Data Source=PriorityRoute/PRDB01";
            string stm = "SELECT SQLITE_VERSION()";

            using var con = new SQLiteConnection(cs);
            con.open();

            using var cmd = new SQLiteCommand(stm, con);
            string version = cmd.ExcecuteScalar().ToString();

            Console.WriteLine($"SQLite version: {version}");
        }
    }
}