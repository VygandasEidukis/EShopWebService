﻿using DataAccessLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLibrary.Models;
using System.Drawing;
using DataAccessLibrary.DataAccess;

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
            if (user.RegisterUser())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // Log in user
        // POST: api/User/LogIn
        [Route("Api/User/LogIn")]
        public UserModel LogIn([FromBody]UserModel user)
        {
            if (user != null)
            {
                if (user.LogIn())
                {
                    return UserProcessor.GetUserByUsername(user.Username);
                }
            }
            return null;
        }
    }
}
