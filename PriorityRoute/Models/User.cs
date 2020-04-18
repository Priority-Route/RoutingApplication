using System;
using SQLite;

namespace PriorityRoute.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID {get; set;}
        public int CompanyID {get; set;}
        public int Administrator {get; set;}
        public String Username {get; set;}
        public String Password {get; set;}
    }
}