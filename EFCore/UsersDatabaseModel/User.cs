using System.ComponentModel.DataAnnotations;


namespace cookbookAPI.EFCore.UsersDatabaseModel
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        public int UserRole { get; set; }
    }
}
