using cookbookAPI.Engine.Contract;
using cookbookAPI.Engine.Contract.Model;
using cookbookAPI.Resources.Contract;
using cookbookAPI.Utilities;
using System.Collections.Generic;

namespace cookbookAPI.Engine
{
    public class EligibilityEngine:IEligibilityEngine
    {
        private readonly IUserResource userResource;

        public EligibilityEngine(IUserResource _userResource)
        {
            userResource = _userResource;
        }

        public string DeleteUserIfAuthorized(string username, string loggedInUser, string password)
        {
            if (Authorize(loggedInUser, password))
            {
                string userId = userResource.GetUserId(username);
                return username+userResource.DeleteUser(userId);
            }

            return "Unauthorized operation";
        }

        public User EditUserIfAuthorized(User user, string username, string password)
        {
            if (Authorize(username, password))
            {
                user.Password = "";
                return MapObject.MapObj<Resources.Contract.Model.User,User>(
                                                  userResource.EditUser(MapObject.MapObj<User, Resources.Contract.Model.User>(user)));
            }

            return user;
        }

        public User GetUserIfEligible(string name, string password)
        {
            if (Authorize(name, password))
            {
                return MapObject.MapObj<Resources.Contract.Model.User, User>(userResource.GetUserData(name));
            }

            return new User();
        }

        public List<User> GetUserListForAdmin(string name, string password)
        {
            if (Authorize(name, password))
            {
                return MapObject.MapObjList<Resources.Contract.Model.User, User>(userResource.GetAllUsersData());
            }

            return new List<User>();
        }

        public bool VerifyUserUniqueness(string username)
        {
            return userResource.IsUserUnique(username);
        }

        private bool Authorize(string name, string password)
        {
            string id = userResource.GetUserId(name);
            string salt = userResource.GetSalt(id);
            string dbPassword = userResource.GetPasswod(id);

            password = Encryptor.Encrypt(password, salt);
           
            if (dbPassword == password)
            {
                return true;
            }

            return false;
        }
    }
}
