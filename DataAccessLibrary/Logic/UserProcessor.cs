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
        public static string AllowedFetchUserData { get; set; } = "Id,FirstName, LastName, Email, Username, Icon";
        public static int CreateUser(UserModel user)
        {
            var sql = @"INSERT INTO dbo.Account (FirstName, LastName,Password, Email, Username) 
                    VALUES (@FirstName, @LastName, @Password, @Email, @Username);
                    SELECT CAST(SCOPE_IDENTITY() as int);";

            return DataAccess.DataAccess.SaveData<UserModel>(sql, user);
        }
        
        public static List<UserModel> GetUsers()
        {
            var sql = $"select {AllowedFetchUserData} from dbo.Account;";

            return DataAccess.DataAccess.LoadData<UserModel>(sql);
        }

        public static UserModel GetUser(int id)
        {
            var sql = $"select {AllowedFetchUserData} from dbo.Account where Id = {id};";
            return DataAccess.DataAccess.GetSingleData<UserModel>(sql);
        }

        public static bool IsUsernameUnique(string username)
        {
            var sql = $"select {AllowedFetchUserData} from dbo.Account where Username = '{username}';";
            return DataAccess.DataAccess.LoadData<UserModel>(sql).ToArray().Length == 0;
        }

        public static bool IsValidLogin(UserModel user)
        {
            var sql = $"select {AllowedFetchUserData} from dbo.Account where Username = '{user.Username}' AND Password = '{user.Password}';";
            return DataAccess.DataAccess.LoadData<UserModel>(sql).ToArray().Length == 1;
        }

        public static UserModel GetUserByUsername(string username)
        {
            var sql = $"SELECT {AllowedFetchUserData} From dbo.Account where Username = '{username}';";
            var data = DataAccess.DataAccess.LoadData<UserModel>(sql).ToArray();
            if (data.Length == 1)
                return data[0];
            return null;
        }
    }
}
