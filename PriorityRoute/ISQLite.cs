using System;
using SQLite;

public interface ISQLite
{
    SQLiteAsyncConnection GetConnection();
}
