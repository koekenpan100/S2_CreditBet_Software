using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditBet_S2_Software.Models
{
    public class LoginUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
