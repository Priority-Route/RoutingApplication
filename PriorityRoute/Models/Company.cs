using System;
using System.Collections.Generic;
using SQLite;
using PriorityRoute.Data;

[Table("Company")]
public class Company
{
    [PrimaryKey, AutoIncrement]
    public int ID {get; set;}
    public String Name {get; set;}
    public String License {get; set;}
    public String Expiration {get; set;}
    public int Valid {get; set;}

    DBUserOps uOps = new DBUserOps();
    DBPointOps pOps = new DBPointOps();

    public List<User> Employees;
    public List<Point> Network;

    public Company()
    {
        Employees = uOps.GetEmployees(this.ID);
        Network = pOps.GetNetwork(this.ID);
    }
}