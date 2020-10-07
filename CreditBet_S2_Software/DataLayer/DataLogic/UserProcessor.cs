using DataLayer.DataAccess;
using DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DataLogic
{
    public class UserProcessor
    {
        public static void CreateUser(string email, string password, string name, string postalcode , string address , string description , string profilepicturepath , int credits , string role)
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
                Role = role
            };
            string sql = @"INSERT INTO employee (email, password, name, postalcode, address, description, profilepicturepath, credits, role)
                            VALUES(@Email, @Password, @Name, @PostalCode, @Address, @Description, @ProfilePicturePath, @Credits,@Role);";
            DatabaseAccess.SaveData(sql, data);
        }
    }
}
