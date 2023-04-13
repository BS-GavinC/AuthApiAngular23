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

        public bool Delete(User user)
        {
            try
            {
                _context.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool EmailAlreadyUsed(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetByEmail(string email)
        {
            try
            {
                return _context.Users.First(u => u.Email == email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public User? GetById(int id)
        {
            try
            {
                return _context.Users.First(u => u.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }


        public User? Update(User user)
        {
            try
            {
                _context.Update(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
