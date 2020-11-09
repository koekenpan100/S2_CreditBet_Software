using DataLayer.DataAccess;
using DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DataLogic
{
    public class UserProcessor
    {
        public static void CreateUser(string email, string password, string name, string postalcode , string address , string description , string profilepicturepath , int credits , string userrole)
        {
            UserDataModel data = new UserDataModel
            {
                Email = email,
                Password = password,
                Name = name,
                PostalCode = postalcode,
                Address = address,
                Description = description,
                ProfilePicturePath = profilepicturepath,
                Credits = credits,
                UserRole = userrole
            };
            string sql = @"INSERT INTO user (email, password, name, postalcode, address, description, profilepicturepath, credits, userrole)
                            VALUES(@Email, @Password, @Name, @PostalCode, @Address, @Description, @ProfilePicturePath, @Credits, @UserRole);";
            DatabaseAccess.SaveData(sql, data);
        }
    }
}
