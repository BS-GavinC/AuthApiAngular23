﻿using DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO.User
{
    public class ChangeRoleDTO
    {
        [Required]
        public Roles role { get; set; }

    }
}
