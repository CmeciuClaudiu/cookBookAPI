using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cookbookAPI.EFCore.UsersDatabaseModel
{
    public class Messages
    {
        [Key]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}
