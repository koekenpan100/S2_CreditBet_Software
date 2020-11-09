using System.ComponentModel.DataAnnotations;

namespace CreditBet_S2_Software.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        public string Password { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "PostalCode")]
        public string PostalCode { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public string ProfilePicturePath { get; set; }

        [Display(Name = "Credits")]
        public int Credits { get; set; }

        [Display(Name = "Role")]
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        [Display(Name = "User")]
        User,
        [Display(Name = "Admin")]
        Admin
    }
}
