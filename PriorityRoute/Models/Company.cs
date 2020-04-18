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
        DBReceptacleOps recOps = new DBReceptacleOps();

        public List<User> Employees;
        public List<Receptacle> Network;

        public Company()
        {
            Employees = userOps.GetEmployees(this.ID);
            Network = recOps.GetNetwork(this.ID);
        }
    }
}