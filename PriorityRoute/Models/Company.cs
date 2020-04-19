// File name: Company.cs
// Purpose: Create and manage companies and their information
// 
// @author Christian Hakim

using System;
using System.Collections.Generic;
using SQLite;
using PriorityRoute.Data;

namespace PriorityRoute.Models
{
    [Table("Company")]
    public class Company
    {
        // setting database values (only int or String)
        [PrimaryKey, AutoIncrement]
        public int ID {get; set;}
        public String Name {get; set;}

        // creating objects to access user and receptacle databases
        DBUserOps userOps;
        DBReceptacleOps recOps;

        // creating objects for company users (employees) and receptacles (network)
        public List<User> Employees;
        public List<Receptacle> Network;

        public Company()
        {
            // instantiating database access objects
            this.recOps = new DBReceptacleOps();
            this.userOps = new DBUserOps();

            // retrieving user and receptacle information from database
            Employees = userOps.GetEmployees(this.ID);
            Network = recOps.GetNetwork(this.ID);
        }

        // manually updating the employees from database
        // returns List of user objects
        public List<User> UpdateEmployees()
        {
            return Employees = userOps.GetEmployees(this.ID);
        }

        // manually updating the network from database
        // returns List of receptacle objects
        public List<Receptacle> UpdateNetwork()
        {
            return Network = recOps.GetNetwork(this.ID);
        }
    }
}