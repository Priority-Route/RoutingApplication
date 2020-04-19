using System;
using Xamarin.Forms.Maps;

namespace PriorityRoute.Models
{
    public class Directions
    {
        private String APIKey = "AIzaSyCM35yVDMoWOYdyPkBc1r4iXieivhP4PqA";

        public String CreateURL(Position start, Position end)
        {
            return "https://maps.googleapis.com/maps/api/directions/json?origin=" + start.Latitude + "," + start.Longitude + "&destination=" + end.Latitude + "," + end.Longitude + "&key=your" + this.APIKey;
        }
    }
}
