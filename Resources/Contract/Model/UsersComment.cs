using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cookbookAPI.Resources.Contract.Model
{
    public class UsersComment
    {
        public string Id { get; set; }

        public string RecipesId { get; set; }

        public string UserName { get; set; }

        public string? Message { get; set; }

        public int Rating { get; set; }

        public DateTime CurrentDate { get; set; }
    }
}
