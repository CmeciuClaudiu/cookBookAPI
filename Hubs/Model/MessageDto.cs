using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookbookAPI.Hubs.Model
{
    public class MessageDto
    {
            public string Username { get; set; }
            public string Message { get; set; }
            public DateTime DateTime { get; set; }
    }
}
