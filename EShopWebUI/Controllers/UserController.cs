using DataAccessLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLibrary.Models;

namespace EShopWebUI.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public List<UserModel> Get()
        {
            return UserProcessor.GetUsers();
        }

        // GET: api/User/5
        public UserModel Get(int id)
        {
            return UserProcessor.GetUser(id);
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
