using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.DataModels;
using DataLayer.DataAccess;

namespace DataLayer.DataLogic
{
    public class ItemProcessor
    {
        public static void CreateItem(string name, string description, decimal price, string category)
        {
            ItemDataModel data = new ItemDataModel
            {
                Name = name,
                Description = description,
                Price = price,
                Category = category
            };
            string sql = @"INSERT INTO user (name, description, price, category)
                            VALUES(@Name, @Description, @Price, @Category);";
            DatabaseAccess.SaveData(sql , data);
        }

        public static List<ItemDataModel> LoadItems()
        {
            string sql = "SELECT * FROM item";
            return DatabaseAccess.LoadData<ItemDataModel>(sql);
        }
        
        public static void DeleteItem(int id)
        {
            string sql = $"DELETE FROM item WHERE id = '{id}';";
            DatabaseAccess.DeleteData(sql);
        }
    }
}
