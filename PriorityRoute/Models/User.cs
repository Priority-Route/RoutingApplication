// File name: User.cs
// Purpose: Create and manage users and their information
// 
// @author Christian Hakim

using System;
using SQLite;

namespace PriorityRoute.Models
{
    [Table("User")]
    public class User
    {
        // setting database values (only int or String)
        [PrimaryKey, AutoIncrement]
        public int ID {get; set;}
        public int CompanyID {get; set;}
        public int Administrator {get; set;}
        public String Username {get; set;}
        public String Password {get; set;}

        public override string ToString()
        {
            return this.Username + "(" + this.Username + ")";
        }
    }
}