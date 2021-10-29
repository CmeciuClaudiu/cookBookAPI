using cookbookAPI.Managers.Contract.Model;
using System.Collections.Generic;

namespace cookbookAPI.Managers.Contract
{
    public interface IUsersManager
    {
        User GetUserDetails(string name, string password);
        User PostUserInDB(User user);
        List<User> GetAllUsersList(string name, string password);
        User EditUserInDb(User user,string username, string password);
        string DeleteUserFromDb(string username, string loggedInUser, string password);
    }
}
