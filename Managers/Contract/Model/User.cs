using System.ComponentModel.DataAnnotations;

namespace cookbookAPI.Managers.Contract.Model
{
    public class User
    {
        public string Id { get; set; }
         
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Range(1, 5)]
        public int UserRole { get; set; }

        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]
        public string Email { get; set; }

        [MinLength(6)]
        public string Password { get; set; }

    }
}
