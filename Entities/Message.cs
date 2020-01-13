﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Message
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Chat Chat { get; set; }
        public string Text { get; set; }
    }
}
