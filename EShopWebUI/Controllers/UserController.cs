using DataAccessLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLibrary.Models;
using System.Drawing;

namespace EShopWebUI.Controllers
{
    public class UserController : ApiController
    {
        // Geta all users
        // GET: api/User
        public List<UserModel> Get()
        {
            return UserProcessor.GetUsers();
        }

        // Get a specific user by its ID
        // GET: api/User/5
        public UserModel Get(int id)
        {
            return UserProcessor.GetUser(id);
        }

        // Register user
        // POST: api/User
        public int Post([FromBody]UserModel user)
        {
            return UserProcessor.CreateUser(user);
        }

        // Log in user
        // POST: api/User/LogIn
        [Route("Api/User/LogIn")]
        public UserModel LogIn([FromBody]UserModel user)
        {
            return new UserModel();
        }

        // Update user
        // PUT: api/User/5
        public void Put(int id, [FromBody]UserModel userToUpdate)
        {

        }
    }
}
