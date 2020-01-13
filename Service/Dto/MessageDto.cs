using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class MessageDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public ChatDto Chat { get; set; }
        public string Text { get; set; }
    }
}
