using System;
using SQLite;

public interface ISQLite
{
    SQLiteConnection GetConnection();
}
