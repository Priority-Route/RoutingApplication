using System;
using System.Collections.Generic;
using SQLite;

[Table("Point")]
public class Point
{
    [PrimaryKey, AutoIncrement]
    public int Designation {get; set;}
    public int CompanyID {get; set;}
    public int Status {get; set;}
    public String Latitude {get; set;}
    public String Longitude {get; set;}
    public String Address {get; set;}
    public int ZipCode {get; set;}
    public String AddInfo {get; set;}
}