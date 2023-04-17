using BLL.Interfaces;
using DAL.Enums;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.DTO.User;
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
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public UserViewModel? Create(CreateUserDto userDto)
        {
            return _userRepository.Create(userDto.ToUser())?.ToUserViewModel();
        }

        public bool Delete(int id)
        {
            User? user = _userRepository.GetById(id);
            return user is not null ? _userRepository.Delete(user) : false;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _userRepository.GetAll().ToUserViewModelList();
        }

        public UserViewModel? GetByEmail(string Email)
        {
            return _userRepository.GetByEmail(Email)?.ToUserViewModel();
        }

        public UserViewModel? GetById(int id)
        {
            return _userRepository.GetById(id)?.ToUserViewModel();
        }

        public string? Login(LoginDTO loginDto)
        {
            if (_userRepository.EmailAlreadyUsed(loginDto.Email)) 
            { 
                User user = _userRepository.GetByEmail(loginDto.Email);
                if (user?.Password == loginDto.Password)
                {

                    //Generation du JWT Token

                    return _jwtService.GenerateToken(user);
                }
            }

            return null;
        }

        public UserViewModel? UpdateDatas(int id, ChangeDataDTO changeDataDTO)
        {
            User? user = _userRepository.GetById(id);

            if (user is not null) 
            { 
                user.Pseudo = changeDataDTO.Pseudo;
                user.Firstname = changeDataDTO.Firstname;
                user.Lastname = changeDataDTO.Lastname;

                return _userRepository.Update(user)?.ToUserViewModel();
            }

            return null;
        }

        public UserViewModel? UpdatePassword(int id, ChangePasswordDTO changePasswordDTO)
        {
            User? user = _userRepository.GetById(id);

            if (user is not null && user.Password == changePasswordDTO.ActualPassword)
            {
                user.Password = changePasswordDTO.NewPassword;

                return _userRepository.Update(user)?.ToUserViewModel();
            }

            return null;
        }

        public UserViewModel? UpdatePhoneNumber(int id, ChangePhoneNumberDTO changePhoneNumberDTO)
        {
            User? user = _userRepository.GetById(id);

            if (user is not null)
            {
                user.PhoneNumber = changePhoneNumberDTO.PhoneNumber;

                return _userRepository.Update(user)?.ToUserViewModel();
            }

            return null;
        }

        public UserViewModel? UpdateRole(int id, ChangeRoleDTO changeRoleDTO)
        {
            User? user = _userRepository.GetById(id);

            if (user is not null && Enum.IsDefined(typeof(Roles), changeRoleDTO.role))
            {
                user.Role = changeRoleDTO.role;

                return _userRepository.Update(user)?.ToUserViewModel();
            }

            return null;
        }
    }
}
