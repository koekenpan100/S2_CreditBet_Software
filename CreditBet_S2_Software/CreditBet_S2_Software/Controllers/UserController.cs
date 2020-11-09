﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DataLayer.DataLogic;
using CreditBet_S2_Software.Models;
using LogicLayer;
using DataLayer.DataModels;

namespace CreditBet_S2_Software.Controllers
{
    public class UserController : Controller
    {

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(UserModel user)
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
                    user.Credits = 100,
                    user.Role.ToString()
                    );
                return RedirectToAction("Index" , "Home");
            }
            return View();
        }
    }
}
