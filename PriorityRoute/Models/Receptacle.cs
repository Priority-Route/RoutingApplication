// File name: Receptacle.cs
// Purpose: Create and manage receptacles and their information
// 
// @author Christian Hakim

using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms.Maps;

namespace PriorityRoute.Models
{
    [Table("Receptacle")]
    public class Receptacle
    {
        // setting database values (only int or String)
        [PrimaryKey, AutoIncrement]
        public int ID {get; set;}
        public int CompanyID {get; set;}
        public int Status {get; set;}
        public String Name {get; set;}
        public String Latitude {get; set;}
        public String Longitude {get; set;}
        public String Label {get; set;}
        public String Type {get; set;}

        public Position Location;

        public Receptacle()
        {
            // converting String values to doubles for Position object

            double lat = Convert.ToDouble(this.Latitude);
            double lon = Convert.ToDouble(this.Longitude);

            // setting location object with values from database
            this.Location = new Position(lat, lon);
        }

        public override string ToString()
        {
            return this.Name + "(" + this.Name + ")";
        }
    }
}