using System;

namespace TresMariasWebApp.Models
{
    public class Route
    {
        public Int32 Id { get; set; }
        public User User { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string OriginLatitude { get; set; }
        public string DestinationLatitude { get; set; }

        public string OriginLongitude { get; set; }
        public string DestinationLongitude { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
