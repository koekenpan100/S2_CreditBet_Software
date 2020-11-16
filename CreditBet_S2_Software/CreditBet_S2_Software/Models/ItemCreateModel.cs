using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CreditBet_S2_Software.Models
{
    public class ItemCreateModel
    {
        public int Id { get; set; }
    
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter a name for the item")]
        [StringLength(50, MinimumLength = 5 , ErrorMessage = "Name of the item must be at least 5 characters and max 50 characters")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Enter a description for the item")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Name of the item must be at least 5 characters and max 200 characters")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Enter a price for the item")]
        [Range(1 , int.MaxValue , ErrorMessage = "Item price must be at least 1")]
        public int Price { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Enter a category for the item")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Category must contain at least 1 character")]
        public string Category { get; set; }
    }
}
