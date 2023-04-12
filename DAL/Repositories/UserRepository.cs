using DAL.Context;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly AuthDbContext _context;

        public UserRepository(AuthDbContext authDbContext)
        {
            _context = authDbContext;
        }

        public User? Create(User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return null;
            }
        }

        public bool EmailAlreadyUsed(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}
