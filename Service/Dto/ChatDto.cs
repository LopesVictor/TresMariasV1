using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class ChatDto
    {
        public UserDto userFrom { get; set; }
        public UserDto userTo { get; set; }
        public Int32 Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
