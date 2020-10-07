using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DataLayer.DataLogic;
using CreditBet_S2_Software.Models;
using LogicLayer;
using DataLayer.DataModels;

namespace CreditBet_S2_Software.Controllers
{
    public class UserController : Controller
    {
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                UserProcessor.CreateUser(
                    user.Email,
                    user.Password,
                    user.Name,
                    user.PostalCode,
                    user.Address,
                    user.Description,
                    user.ProfilePicturePath,
                    user.Credits,
                    user.Role.ToString()
                    );
            }
            return RedirectToAction("Index", "User");
        }


    }
}
