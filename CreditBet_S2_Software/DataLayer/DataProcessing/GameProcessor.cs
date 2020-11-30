using DataLayer.DataAccess;
using DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DataLogic
{
    public class GameProcessor
    {
        DatabaseAccess access = new DatabaseAccess();

        public GameDataModel LoadGameById(int id)
        {
            string sql = $"SELECT * FROM game WHERE id = '{id}';";
            return access.LoadFirstData<GameDataModel>(sql);
        }
    }
}
