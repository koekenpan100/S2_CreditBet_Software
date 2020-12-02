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
                return RedirectToAction("ViewItems", "Shop");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ViewItems()
        {
            var data = processor.LoadItems();
            List<ViewItemModel> items = new List<ViewItemModel>();
            foreach (var row in data)
            {
                items.Add(new ViewItemModel
                {
                    Id = row.ID,
                    Name = row.Name,
                    Description = row.Description,
                    Price = row.Price,
                    Category = row.Category
                });
            }
            return View(items);
        }

        [HttpPost]
        public IActionResult DeleteItem(int Id)
        {
            processor.DeleteItem(Id);
            return RedirectToAction("ViewItems");
        }
    }
}
