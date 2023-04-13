using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO.User
{
    public class ChangePhoneNumberDTO
    {
        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

    }
}
