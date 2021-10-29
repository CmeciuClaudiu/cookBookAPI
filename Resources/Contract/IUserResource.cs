using cookbookAPI.Resources.Contract.Model;
using System.Collections.Generic;

namespace cookbookAPI.Resources.Contract
{
    public interface IUserResource
    {
        string SaveUser(User user);
        string GetPasswod(string id);
        string GetSalt(string id);
        User GetUserData(string username);
        string GetUserId(string username);
        List<User> GetAllUsersData();
        string DeleteUser(string id);
        User EditUser(User user);
        bool IsUserUnique(string username);
    }
}
