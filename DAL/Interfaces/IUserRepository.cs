using DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {

        public User? Create(User user);

        public bool EmailAlreadyUsed(string email);

        public User? GetByEmail(string email);

        public User? GetById(int id);

        public IEnumerable<User> GetAll();

        public User? Update(User user);

        public bool Delete(User user);

    }
}
