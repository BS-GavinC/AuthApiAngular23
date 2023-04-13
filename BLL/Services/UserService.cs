﻿using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.DTO;
using DAL.Models.Mapper;
using DAL.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserViewModel? Create(CreateUserDto userDto)
        {
            return _userRepository.Create(userDto.ToUser())?.ToUserViewModel();
        }

        public string? Login(LoginDTO loginDto)
        {
            if (_userRepository.EmailAlreadyUsed(loginDto.Email)) 
            { 
                User user = _userRepository.GetByEmail(loginDto.Email);
                if (user?.Password == loginDto.Password)
                {

                    //Generation du JWT Token

                    return "Mon Beau Token : " + user?.Pseudo;
                }
            }

            return null;
        }
    }
}
