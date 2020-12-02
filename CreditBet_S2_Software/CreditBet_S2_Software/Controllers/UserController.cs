using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.DataLogic;
using CreditBet_S2_Software.Models;
using LogicLayer;
using DataLayer.DataModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace CreditBet_S2_Software.Controllers
{
    public class UserController : Controller
    {
        UserProcessor processor = new UserProcessor();

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(UserCreateModel user)
        {
            if (ModelState.IsValid)
            {
                string salt = PassWordHashing.GenerateSalt();
                string PasswordHash = PassWordHashing.GeneratePasswordHash(user.Password, salt);
                processor.CreateUser(
                    user.Email,
                    salt,
                    PasswordHash,
                    user.Name,
                    user.Postalcode,
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

        [HttpGet]
        public IActionResult LoginUser()
        {
            if (@User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginUserModel login)
        {
            if (ModelState.IsValid)
            {
                UserDataModel userData = processor.GetUserFromEmail(login.Email);
                if (userData != null)
                {
                    if (PassWordHashing.ValidateUser(login.Password, userData.Salt, userData.PasswordHash))
                    {
                        var userIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                        userIdentity.AddClaim(new Claim(ClaimTypes.Name, userData.Name));
                        userIdentity.AddClaim(new Claim(ClaimTypes.Email, userData.Email));
                        userIdentity.AddClaim(new Claim(ClaimTypes.Role, userData.UserRole));

                        var userPrincipal = new ClaimsPrincipal(userIdentity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);

                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("loginError", "E-mail and password do not match.");
                }
            }
            return View();
        }

        [Authorize]
        public IActionResult LogoutUser()
        {
            if (@User.Identity.IsAuthenticated)
            {
                HttpContext.SignOutAsync();
            }
            return RedirectToAction("LoginUser", "User");
        }
    }
}
