using System;

namespace TresMariasWebApp.Models
{
    public class Chat
    {
        public Chat() { }

        public User userFrom { get; set; }
        public User userTo { get; set; }
        public Int32 Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
