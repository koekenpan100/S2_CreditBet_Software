using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Text;

namespace DataLayer.DataModels
{
    public class UserDataModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string ProfilePicturePath { get; set; }
        public int Credits { get; set; }
        public string UserRole { get; set; }
    }
}
