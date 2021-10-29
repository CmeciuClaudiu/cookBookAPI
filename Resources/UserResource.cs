using cookbookAPI.EFCore.Context;
using cookbookAPI.Resources.Contract;
using cookbookAPI.Resources.Contract.Model;
using cookbookAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cookbookAPI.Resources
{
    public class UserResource : IUserResource
    {
        private readonly UsersDatabaseContext context;
        public UserResource(UsersDatabaseContext _context)
        {
            context = _context;
        }
        public string SaveUser(User user)
        {
            EFCore.UsersDatabaseModel.User userDbObject;
            userDbObject = MapObject.MapObj<User, EFCore.UsersDatabaseModel.User>(user);
            userDbObject.Id = Guid.NewGuid().ToString();

            context.Add(userDbObject);
            context.SaveChanges();

            EFCore.UsersDatabaseModel.AuthDetails authDetailsDbObject = new EFCore.UsersDatabaseModel.AuthDetails();
            authDetailsDbObject.Id = Guid.NewGuid().ToString();
            authDetailsDbObject.Email = user.Email;
            authDetailsDbObject.Key = Encryptor.CreateSaltForEncryption();
            authDetailsDbObject.Password = Encryptor.Encrypt(user.Password,authDetailsDbObject.Key);
            authDetailsDbObject.UsersId = userDbObject.Id;

            context.Add(authDetailsDbObject);
            context.SaveChanges();

            return userDbObject.UserName;
        }

        public string GetPasswod(string id)
        {
            return context.AuthDetails.Where(q => q.UsersId == id)
                                                    .Select(u => u.Password).FirstOrDefault();
        }

        public string GetSalt(string id)
        {
            return context.AuthDetails.Where(q => q.UsersId == id)
                                                    .Select(u=>u.Key).FirstOrDefault();
        }

        public string GetUserId(string username)
        {
            return context.Users.Where(q => q.UserName == username)
                                             .Select(u => u.Id).FirstOrDefault();
        }

        public User GetUserData(string username)
        {
            var userQueryResult = context.Users.FirstOrDefault(u => u.UserName == username);
            var authQueryResult = context.AuthDetails.FirstOrDefault(a => a.UsersId == userQueryResult.Id);
   
            User userDetails = MapObject.MapObj<EFCore.UsersDatabaseModel.User, User >(userQueryResult);
            userDetails.Email = authQueryResult.Email;

            return userDetails;
        }

        public List<User> GetAllUsersData()
        {
            return MapObject.MapObjList<EFCore.UsersDatabaseModel.User, User>(context.Users.Where(p => p.Id != null).ToList());
        }

        public string DeleteUser(string id)
        {
            var userQueryResult = context.Users.FirstOrDefault(u => u.Id == id);
            var authQueryResult = context.AuthDetails.FirstOrDefault(a => a.UsersId == id);

            context.Users.Remove(userQueryResult);
            context.AuthDetails.Remove(authQueryResult);
            context.SaveChanges();

            return " has been succesfully deleted";
        }

        public User EditUser(User user)
        {
            var userQueryResult = context.Users.FirstOrDefault(u => u.Id == user.Id);
            var authQueryResult = context.AuthDetails.FirstOrDefault(a => a.UsersId == user.Id);

            userQueryResult.UserName = user.UserName;
            authQueryResult.Email = user.Email;

            context.Users.Update(userQueryResult);
            context.AuthDetails.Update(authQueryResult);
            context.SaveChanges();

            return user;
        }

        public bool IsUserUnique(string username)
        {
            return context.Users.Any(u=>u.UserName==username);
        }
    }
}
