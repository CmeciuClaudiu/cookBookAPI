using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cookbookAPI.EFCore.UsersDatabaseModel
{
    public class UserComment
    {
        public string Id { get; set; }

        public string RecipesId { get; set; }

        public string UserName { get; set; }

        public string? Message { get; set; }

        public int Rating { get; set; }

        public DateTime CurrentDate { get; set; }
    }
}
