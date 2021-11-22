using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cookbookAPI.Managers.Contract.Model
{
    public class UsersComment
    {
        public string Id { get; set; }

        [Required]
        public string RecipesId { get; set; }

        [Required]
        public string UserName { get; set; }

        public string? Message{ get; set; }

        [Required]
        [Range(1,5)]
        public int Rating { get; set; }

        [Required]
        public DateTime CurrentDate { get; set; }
    }
}
