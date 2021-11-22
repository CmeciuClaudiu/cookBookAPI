using cookbookAPI.Managers.Contract;
using cookbookAPI.Resources.Contract;
using cookbookAPI.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cookbookAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManager usersManager;
        public UsersController(IUsersManager _usersManager)
        {
            usersManager = _usersManager;
        }

        [HttpGet("userDetails")]
        public Managers.Contract.Model.User GetUser(string name,string password)
        {
            return usersManager.GetUserDetails(name, password);
        }

        [HttpGet]
        [Route("userList")]
        public List<Managers.Contract.Model.User> GetUserList(string name, string password)
        {
            return usersManager.GetAllUsersList(name, password);
        }

        [HttpPost]
        public Managers.Contract.Model.User Post(Managers.Contract.Model.User user)
        {
            return usersManager.PostUserInDB(user);
        }

        [HttpPost]
        [Route("comments")]
        public bool PostUsersComments(Managers.Contract.Model.UsersComment userComment)
        {
            return usersManager.PostComment(userComment);
        }

        [HttpGet]
        [Route("comments")]
        public List<Managers.Contract.Model.UsersComment>GetUsersComments(string recipeId)
        {
            return usersManager.GetCommentsForRecipe(recipeId);
        }


        // PUT api/<AccountsController>/5
        [HttpPut]
        public Managers.Contract.Model.User Put(Managers.Contract.Model.User user, string username, string password)
        {
            return usersManager.EditUserInDb(user,username,password);
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete]
        public string Delete(string userName, string loggedInUser, string password)
        {
            return usersManager.DeleteUserFromDb(userName, loggedInUser,password);
        }
    }
}
