using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CreditBet_S2_Software.Models
{
    public class CreateItemModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a name for the item")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a description for the item")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter a price for the item")]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Enter a category for the item")]
        [Display(Name = "Category")]
        public string Category { get; set; }
    }
}
