using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.DataModels;
using DataLayer.DataAccess;

namespace DataLayer.DataLogic
{
    public class ItemProcessor
    {
        DatabaseAccess access = new DatabaseAccess();

        public void CreateItem(string name, string description, int price, string category)
        {
            ItemDataModel data = new ItemDataModel
            {
                Name = name,
                Description = description,
                Price = price,
                Category = category
            };
            string sql = @"INSERT INTO item (name, description, price, category)
                            VALUES(@Name, @Description, @Price, @Category);";
            access.SaveData(sql, data);
        }

        public List<ItemDataModel> LoadItems()
        {
            string sql = "SELECT * FROM item";
            return access.LoadData<ItemDataModel>(sql);
        }

        public void DeleteItem(int id)
        {
            var parameters = new { Id = id };
            string sql = @"DELETE FROM item WHERE ID = @Id;";
            access.DeleteData(sql , parameters);
        }
    }
}
