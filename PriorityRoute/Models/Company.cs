using System;
using System.Collections.Generic;
using System.Data.SQLite;

[Table("Company")]
public class Company
{
    [PrimaryKey, AutoIncrement]
    public int ID {get; set;}
    public String Name {get; set;}
    public String License {get; set;}
    public String Expiration {get; set;}
    public int Valid {get; set;}
}