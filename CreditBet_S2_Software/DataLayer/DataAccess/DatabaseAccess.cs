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
        public string GetConnectionString()
        {
            return "server=localhost;database=CreditBet_DB;username=root";
        }

        public List<T> LoadData<T>(string sql)
        {
            using (IDbConnection con = new MySqlConnection(GetConnectionString()))
            {
                return con.Query<T>(sql).ToList();
            }
        }

        public T LoadFirstData<T>(string sql)
        {
            using (IDbConnection con = new MySqlConnection(GetConnectionString()))
            {
                {
                    return con.Query<T>(sql).FirstOrDefault();
                }
            }
        }

        public void SaveData<T>(string sql, T data)
        {
            using (IDbConnection con = new MySqlConnection(GetConnectionString()))
            {
                con.Execute(sql, data);
            }
        }

        public void DeleteData<T>(string sql , T data)
        {
            using (IDbConnection con = new MySqlConnection(GetConnectionString()))
            {
                con.Execute(sql, data);
            }
        }
    }
}
