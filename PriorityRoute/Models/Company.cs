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

        DBUserOps userOps;
        DBReceptacleOps recOps;

        public List<User> Employees;
        public List<Receptacle> Network;

        public Company()
        {
            this.recOps = new DBReceptacleOps();
            this.userOps = new DBUserOps();
            Employees = userOps.GetEmployees(this.ID);
            Network = recOps.GetNetwork(this.ID);
        }
        public void UpdateNetwork()
        {
            Network = recOps.GetNetwork(this.ID);
        }         public List<Receptacle> GetNetwork()
        {
            return this.Network;
        }
    }
}