using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Logic
{
    public static class UserProcessor
    {
        public static int CreateUser(UserModel user)
        {
            var sql = @"INSERT INTO dbo.Account (FirstName, LastName,Password, Email, Username, Icon) 
                    VALUES (@FirstName, @LastName, @Password, @Email, @Username, @Icon);";

            return DataAccess.DataAccess.SaveData<UserModel>(sql, user);
        }
        
        public static List<UserModel> GetUsers()
        {
            var sql = @"select * from dbo.Account;";

            return DataAccess.DataAccess.LoadData<UserModel>(sql);
        }

        public static UserModel GetUser(int id)
        {
            var sql = $"select * from dbo.Account where Id = {id};";
            return DataAccess.DataAccess.GetSingleData<UserModel>(sql);
        }

        public static bool IsUsernameUnique(string username)
        {
            var sql = $"select * from dbo.Account where Username = '{username}'";
            return DataAccess.DataAccess.LoadData<UserModel>(sql).ToArray().Length == 0;
        }
    }
}
