using System.ComponentModel.DataAnnotations;


namespace cookbookAPI.EFCore.UsersDatabaseModel
{
    public class AuthDetails
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UsersId { get; set; }
        public string Key { get; set; }
    }
}
