using DAL.Models;
using DAL.Models.DTO;
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

    }
}
