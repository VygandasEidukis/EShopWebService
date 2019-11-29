using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Logic
{
    public static class SearchProcessor
    {
        public static List<UserModel> SearchByUsername(string username)
        {
            string sql = $"SELECT {UserProcessor.AllowedFetchUserData} FROM dbo.Account WHERE Username LIKE '%{username}%';";
            return DataAccess.DataAccess.LoadData<UserModel>(sql);
        }
    }
}
