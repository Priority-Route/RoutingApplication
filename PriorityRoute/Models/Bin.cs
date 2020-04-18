using System;
using System.Collections.Generic;
using SQLite;

namespace PriorityRoute.Models
{
    [Table("Bin")]
    public class Bin
    {
        [PrimaryKey, AutoIncrement]
        public int ID {get; set;}
        public int CompanyID {get; set;}
        public int Status {get; set;}
        public String Latitude {get; set;}
        public String Longitude {get; set;}
    }
}