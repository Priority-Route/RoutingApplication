// File name: Directions.cs
// Purpose: Provide a URL given two points to fetch direction data from Google Maps
// 
// @author Christian Hakim and Phillip Ruggirello

using System;
using Xamarin.Forms.Maps;

namespace PriorityRoute.Models
{
    public class Directions
    {
        // Google API key
        private String APIKey = "AIzaSyCM35yVDMoWOYdyPkBc1r4iXieivhP4PqA";

        // creates a Google directions path URL
        // requires Position starting location
        // requires Position ending location
        // returns String of the URL needed to access direction information
        public String CreateURL(Position start, Position end)
        {
            return "https://maps.googleapis.com/maps/api/directions/json?origin=" + start.Latitude + "," + start.Longitude + "&destination=" + end.Latitude + "," + end.Longitude + "&key=your" + this.APIKey;
        }
    }
}
