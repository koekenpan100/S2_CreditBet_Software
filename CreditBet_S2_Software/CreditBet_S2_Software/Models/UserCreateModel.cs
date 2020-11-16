using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

namespace CreditBet_S2_Software.Models
{
    public class UserCreateModel
    {
        public int Id { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Enter an e-mail address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter a valid e-mail address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Confirm e-mail")]
        [Display(Name = "Confirm e-mail")]
        [Compare("Email", ErrorMessage = "E-mail addresses don't match , try again")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Password has to be a minimum of 5 characters and a maximum of 15")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password")]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match , try again")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter a name to be displayed on your profile")]
        [Display(Name = "Name")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Name must be at least 2 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a description to be displayed on your profile")]
        [Display(Name = "Description")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Description must be at least 2 characters")]
        public string Description { get; set; }

        [Display(Name = "Profile Picture")]
        [StringLength(500)]
        public string ProfilePicturePath { get; set; }

        [Required(ErrorMessage = "Enter a postal code")]
        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        public string Postalcode { get; set; }

        [Required(ErrorMessage = "Enter an address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Enter User Role")]
        [Display(Name = "Role")]
        public UserRole Role { get; set; }

        public int Credits { get; set; }
    }
}
