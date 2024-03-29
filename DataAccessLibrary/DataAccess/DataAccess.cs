﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLibrary.DataAccess
{
    public class DataAccess
    {
        private static string GetConnectionString(string connectionName = "EShioSQLDatabase")
        {
            return ConfigurationManager.ConnectionStrings[1].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using(IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var response = cnn.Query<int>(sql, data).Single();
                return response;
                throw new Exception("Unexpected error while writing data");
            }
        }

        public static void ExecuteQuery(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Query(sql);
            }
        }

        public static void UpdateQuery<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Query<int>(sql, data);
            }
        }

        public static T GetSingleData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList()[0];
            }
        }        
    }
}
