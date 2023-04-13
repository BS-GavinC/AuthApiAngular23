using DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        public User()
        {
            
        }

        public User(string pseudo, string email, string password)
        {
            Pseudo = pseudo;
            Email = email;
            Password = password;
            Role = Roles.user;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [MaxLength(50)]
        public string? Firstname { get; set; }


        [MaxLength(50)]
        public string? Lastname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Pseudo { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=!]).{8,25}$")] 
        public string Password { get; set; }

        [MaxLength(50)]
        public string? PhoneNumber { get; set; }

        [Required]
        public Roles Role { get; set; }

    }
}
