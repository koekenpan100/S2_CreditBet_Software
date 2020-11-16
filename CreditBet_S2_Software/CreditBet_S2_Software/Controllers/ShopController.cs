using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.DataLogic;
using CreditBet_S2_Software.Models;
using Microsoft.AspNetCore.Mvc;
using DataLayer.DataModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;


namespace CreditBet_S2_Software.Controllers
{
    public class ShopController : Controller
    {
        ItemProcessor processor = new ItemProcessor();

        [HttpGet]
        public IActionResult CreateItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateItem(ItemModel item)
        {
            if (ModelState.IsValid)
            {
                processor.CreateItem(
                    item.Name,
                    item.Description,
                    item.Price,
                    item.Category
                    );
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ViewItems()
        {
            var data = processor.LoadItems();
            List<ItemModel> employees = new List<ItemModel>();
            foreach (var row in data)
            {
                employees.Add(new ItemModel
                {
                    Name = row.Name,
                    Description = row.Description,
                    Price = row.Price,
                    Category = row.Category
                });
            }
            return View(employees);
        }
    }
}
