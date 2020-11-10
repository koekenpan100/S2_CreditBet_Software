using DataLayer.DataAccess;
using DataLayer.DataModels;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DataLogic
{
    public class UserProcessor
    {
        public static void CreateUser(string email, string salt , string passwordhash, string name, string postalcode , string address , string description , string profilepicturepath , int credits , string userrole)
        {
            UserDataModel data = new UserDataModel
            {
                Email = email,
                Salt = salt,
                PasswordHash = passwordhash,
                Name = name,
                PostalCode = postalcode,
                Address = address,
                Description = description,
                ProfilePicturePath = profilepicturepath,
                Credits = credits,
                UserRole = userrole
            };
            string sql = @"INSERT INTO user (email, salt, passwordhash, name, postalcode, address, description, profilepicturepath, credits, userrole)
                            VALUES(@Email, @Salt, @PasswordHash, @Name, @PostalCode, @Address, @Description, @ProfilePicturePath, @Credits, @UserRole);";
            DatabaseAccess.SaveData(sql, data);
        }

        public static UserDataModel GetUserFromEmail(string email)
        {
            string sql = $"SELECT * FROM user WHERE email = '{email}';";
            return DatabaseAccess.LoadFirstData<UserDataModel>(sql);
        }

        public static UserDataModel GetUserFromId(int id)
        {
            string sql = $"SELECT * FROM user WHERE id = '{id}';";
            return DatabaseAccess.LoadFirstData<UserDataModel>(sql);
        }
    }
}
