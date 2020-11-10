using DataLayer.DataAccess;
using DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DataLogic
{
    public class GameProcessor
    {
        public static GameDataModel LoadGameById(int id)
        {
            string sql = $"SELECT * FROM game WHERE id = '{id}';";
            return DatabaseAccess.LoadFirstData<GameDataModel>(sql);
        }
    }
}
