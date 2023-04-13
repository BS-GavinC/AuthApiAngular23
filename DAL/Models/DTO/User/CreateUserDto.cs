using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO.User
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=!]).{8,25}$")]
        public string Password { get; set; }


        [Compare("Password")]
        public string PasswordConfirmation { get; set; }


        [Required]
        [MaxLength(50)]
        public string Pseudo { get; set; }

    }
}
