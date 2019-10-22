using DataAccessLibrary.Logic;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EShopWebUI.Controllers
{
    public class SearchController : ApiController
    {
        [HttpGet]
        [Route("api/Search/username/{username}")]
        public List<UserModel> SearchUserByUsername(string username)
        {
            return SearchProcessor.SearchByUsername(username);
        }
    }
}
