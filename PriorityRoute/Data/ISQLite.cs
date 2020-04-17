using System;
using SQLite;

namespace PriorityRoute.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
