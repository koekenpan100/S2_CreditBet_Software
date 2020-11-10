using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CreditBet_S2_Software.Models;
using DataLayer.DataModels;
using DataLayer.DataLogic;

namespace CreditBet_S2_Software.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public IActionResult LoadCoinflip()
        {
            GameDataModel gameData = GameProcessor.LoadGameById(1);
            ViewGameModel game = new ViewGameModel
            {
                Name = gameData.Name,
                Description = gameData.Description
            };
            return View(game);
        }
    }
}
