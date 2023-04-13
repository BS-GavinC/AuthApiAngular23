using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO.User
{
    public class ChangeDataDTO
    {
        [MaxLength(50)]
        public string Firstname { get; set; }

        [MaxLength(50)]
        public string Lastname { get; set; }


        [Required]
        [MaxLength(50)]
        public string Pseudo { get; set; }

    }
}
