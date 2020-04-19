using System;
using SQLite;

namespace PriorityRoute.Data
{
    public interface ISQLite
    {
        // creates connection object specific to SQLite
        SQLiteConnection GetConnection();
    }
}
