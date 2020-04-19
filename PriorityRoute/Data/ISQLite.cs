// File name: ISQLite.cs
// Purpose: provide a connection interface for prefix-"DB" documents to connect to the database
// 
// @author Phillip Ruggirello

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
