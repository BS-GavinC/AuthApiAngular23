using DAL.Models.DTO.User;
using DAL.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Mapper
{
    public static class UserMapper
    {

        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel {
                Id = user.Id,
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                PhoneNumber = user.PhoneNumber,
                Pseudo = user.Pseudo,
                Role = user.Role
            };
        }

        public static User ToUser(this CreateUserDto userdto) 
        {
            return new User(userdto.Pseudo, userdto.Email, userdto.Password);
        }

        public static IEnumerable<UserViewModel> ToUserViewModelList(this IEnumerable<User> users) 
        { 
            List<UserViewModel> list = new List<UserViewModel>();
            foreach (var user in users)
            {
                list.Add(user.ToUserViewModel());
            }
            return list;
        }

    }
}
