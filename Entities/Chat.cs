using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Chat
    {
        public Chat() { }

        public Chat(Int32 id)
        {
            Id = id;
        }

        public User userFrom { get; set; }
        public User userTo { get; set; }
        public Int32 Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
