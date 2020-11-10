using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditBet_S2_Software.Models;
using DataLayer.DataLogic;
using Microsoft.AspNetCore.Mvc;

namespace CreditBet_S2_Software.Controllers
{
    public class CreditManagerController : Controller
    {
        [HttpGet]
        public IActionResult AddCredits()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCredits(int credits)
        {
            UserModel user = new UserModel();
            user.Credits += credits;
            return View();
        }

        [HttpPost]
        public IActionResult RemoveCredits(int credits)
        {
            UserModel user = new UserModel();
            user.Credits -= credits;
            return View();
        }
    }
}
