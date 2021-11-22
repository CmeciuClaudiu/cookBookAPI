using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookbookAPI.Resources.Contract.Model
{
    public class ChatMsg
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}
