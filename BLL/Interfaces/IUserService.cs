using DAL.Models;
using DAL.Models.DTO.User;
using DAL.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {

        public UserViewModel? Create(CreateUserDto userDto);

        public string? Login(LoginDTO loginDto);

        public UserViewModel? UpdatePassword(int id, ChangePasswordDTO changePasswordDTO);

        public UserViewModel? UpdatePhoneNumber(int id, ChangePhoneNumberDTO changePhoneNumberDTO);

        public UserViewModel? UpdateDatas(int id, ChangeDataDTO changeDataDTO);

        public UserViewModel? UpdateRole(int id, ChangeRoleDTO changeRoleDTO);

        public UserViewModel? GetById(int id);

        public UserViewModel? GetByEmail(string Email);

        public IEnumerable<UserViewModel> GetAll();

        public bool Delete(int id);

    }
}
