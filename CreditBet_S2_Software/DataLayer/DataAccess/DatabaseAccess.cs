using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using MySql.Data.MySqlClient;

namespace DataLayer.DataAccess
{
    public class DatabaseAccess
    {
        public static string GetConnectionString()
        {
            return "";
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection con = new MySqlConnection(GetConnectionString()))
            {
                return con.Query<T>(sql).ToList();
            }
        }

        public static T LoadFirstData<T>(string sql)
        {
            using (IDbConnection con = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    return con.Query<T>(sql).FirstOrDefault();
                }
                catch (InvalidCastException e)
                {
                    return default;
                }
            }
        }

        public static void SaveData<T>(string sql, T data)
        {
            using (IDbConnection con = new MySqlConnection(GetConnectionString()))
            {
                con.Execute(sql, data);
            }
        }

        public static void DeleteData(string sql)
        {
            using (IDbConnection con = new MySqlConnection(GetConnectionString()))
            {
                con.Execute(sql);
            }
        }
    }
}
