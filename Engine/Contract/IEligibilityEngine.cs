using cookbookAPI.Engine.Contract.Model;
using System.Collections.Generic;

namespace cookbookAPI.Engine.Contract
{
    public interface IEligibilityEngine
    {
       User GetUserIfEligible(string name, string password);
       List<User> GetUserListForAdmin(string name, string password);
       User EditUserIfAuthorized(User user, string username, string password);
       string DeleteUserIfAuthorized(string username, string loggedInUser, string password);
       bool VerifyUserUniqueness(string username);
    }
}
