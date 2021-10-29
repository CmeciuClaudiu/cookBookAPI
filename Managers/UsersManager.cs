using cookbookAPI.Engine.Contract;
using cookbookAPI.Managers.Contract;
using cookbookAPI.Managers.Contract.Model;
using cookbookAPI.Resources.Contract;
using cookbookAPI.Utilities;
using System.Collections.Generic;

namespace cookbookAPI.Managers
{
    public class UsersManager : IUsersManager
    {
        private readonly IUserResource userResource;
        private readonly IEligibilityEngine eligibilityEngine;
        public UsersManager(IUserResource _userResource, IEligibilityEngine _eligibilityEngine)
        {
            userResource = _userResource;
            eligibilityEngine = _eligibilityEngine;
        }

        public string DeleteUserFromDb(string username, string loggedInUser, string password)
        {
            User userData = MapObject.MapObj<Engine.Contract.Model.User, User>(eligibilityEngine.GetUserIfEligible(loggedInUser, password));

            if (userData.UserRole == 1)
            {
                return eligibilityEngine.DeleteUserIfAuthorized(username, loggedInUser, password);
            }

            return "Unauthorized operation!";
        }

        public User EditUserInDb(User user, string username, string password)
        {
            User userData = MapObject.MapObj<Engine.Contract.Model.User, User>(eligibilityEngine.GetUserIfEligible(username, password));

            if (userData.Id == null)
            {
                return new User();
            }

            bool userExists = eligibilityEngine.VerifyUserUniqueness(user.UserName);
           
            if (((!userExists) && (userData.Id==user.Id)) || (userData.Email!=user.Email))
            {
                return MapObject.MapObj<Engine.Contract.Model.User, User>(
                              eligibilityEngine.EditUserIfAuthorized(MapObject.MapObj<User, Engine.Contract.Model.User>(user), username, password));
            }

            user.UserName = null;
            user.UserRole = -1;
            return user;
        }

        public List<User> GetAllUsersList(string name, string password)
        {
            User userData = MapObject.MapObj<Engine.Contract.Model.User, User>(eligibilityEngine.GetUserIfEligible(name, password));

            if (userData.UserRole == 1)
            {
                return MapObject.MapObjList<Engine.Contract.Model.User, User>(eligibilityEngine.GetUserListForAdmin(name, password));
            }

            return new List<User>();
        }

        public User GetUserDetails(string name, string password)
        {
            return MapObject.MapObj<Engine.Contract.Model.User, User>(eligibilityEngine.GetUserIfEligible(name, password));
        }

        public User PostUserInDB(User user)
        {
            User usrName = new User();
            if (user.UserRole == 1)
            {
               usrName.UserName = "User with administrator permisions can not be added! ";
                return usrName;
            }
            if (!eligibilityEngine.VerifyUserUniqueness(user.UserName))
            {
                usrName.UserName = userResource.SaveUser(MapObject.MapObj<User, Resources.Contract.Model.User>(user))+" has been added";
                return usrName;
            }

            usrName.UserName = "This username already exists!";
            return usrName;
        }
    }
}
