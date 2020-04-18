using System;
using System.Collections.Generic;
using SQLite;
using PriorityRoute.Data;

namespace PriorityRoute.Models
{
    [Table("Company")]
    public class Company
    {
        [PrimaryKey, AutoIncrement]
        public int ID {get; set;}
        public String Name {get; set;}

        DBUserOps userOps = new DBUserOps();
        DBPinOps pinOps = new DBPinOps();

        public List<User> Employees;
        public List<Pin> Network;

        public Company()
        {
            Employees = userOps.GetEmployees(this.ID);
            Network = pinOps.GetNetwork(this.ID);
        }
    }
}