using DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.ViewModel
{
    public class UserViewModel
    {

        public int Id { get; set; }

        public string Firstname { get; set; }


        public string Lastname { get; set; }

        public string Pseudo { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Roles Role { get; set; }
    }
}
