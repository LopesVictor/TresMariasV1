using System;

namespace Service.Dto
{
    public class RouteDto
    {
        public Int32 Id { get; set; }
        public UserDto User { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
